using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;

enum AttackState
{
    Combo01,
    Combo02,
    Combo03,
}

public enum weapon
{
    Sword,
    Bow,
    Wand,
}

public class PlayerAttackControl : MonoBehaviour
{
    [Header ("animtor")]
    [SerializeField] public Animator anim;
    [SerializeField] public Animator Bowanim;
    [SerializeField] public Animator Arrowanim;
    [SerializeField] public Transform player;

    [Header("Weapons")]
    [SerializeField] private GameObject[] Swords;
    [SerializeField] private GameObject[] Bows;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject[] Wands;
    [SerializeField] public GameObject[] Skills;


    [Header("animtorOverrideController")]
    [SerializeField] private AnimatorOverrideController AOC_Sword;
    [SerializeField] private AnimatorOverrideController AOC_Bow;
    [SerializeField] private AnimatorOverrideController AOC_Wand;

    [Header("Attack Trace")]
    [SerializeField] private GameObject MeleeAtackLoop;

    [Header("CoolTime Image")]
    [SerializeField] Image CoolTime_Img;

    [SerializeField] Text CoolTime_Text;
    public PlayerMovement movement;

    public static Action<uint,int> lifeSteal;

    public static Action StackAttacking;

    public bool isCoolTime;

    private float coolTime_timing;

    uint currentWeapon;

    [Header("Stack Attack")]
    [SerializeField] GameObject StackExplosion;

    public static int AttackStack = 0;
    private void Awake()
    {
        lifeSteal = (itemID, StealPercentage) => { LifeSteal(itemID,StealPercentage); };
        StackAttacking = () => { TripleShot(); };
    }

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        EndDamage();
        WeaponSwitch(301);
    }

    AttackState state = AttackState.Combo01;

    weapon battlestate = weapon.Sword;
    
    public bool isAttacking = false;
    public bool canCombo = false;


    public void TripleShot()
    {

        GameObject Triple = Instantiate(StackExplosion, transform.position, Quaternion.identity);
        var info = Triple.GetComponent<SkillInfoInterface>();
        info.atkCon = this;
    }

    private void Update()
    {
        Debug.Log("Skill Using : " + PlayerMovement.SkillUsing);
        if(!isCoolTime)
        {
            coolTime_timing -= Time.deltaTime;
            CoolTime_Text.text = coolTime_timing.ToString("F1");
            CoolTime_Img.fillAmount = coolTime_timing / SkillDataManager.LoadData(InventoryManager.slot1_id).cooltime;
        }
        else
        {
            CoolTime_Text.text = "";
            CoolTime_Img.fillAmount = 0;
        }
    }
    public void LifeSteal(uint itemID, int StealPercentage)
    {
        float Percentage = StealPercentage * 0.01f;
        var data = ItemDataManager.LoadData(itemID);
        if(itemID == 304)
        {
            Stats.Health += data.ad * (Percentage * 100);
        }
    }
    
    public void AttackStart()
    {
        if (!isAttacking)
        {
            MeleeAtackLoop.SetActive(false);
            SelectAttack();
        }
        else if (isAttacking && canCombo)
        {
            MeleeAtackLoop.SetActive(false);
            canCombo = false;
            SelectAttack();
        }
    }
 
    
    public void Skill()
    {
        if(InventoryManager.slot1_id != 0 && isCoolTime)
        {
            PlayerMovement.SkillUsing = true;
            GameObject skill;
            if(InventoryManager.slot1_id != 301)
            {
                isCoolTime = false;
                coolTime_timing = SkillDataManager.LoadData(InventoryManager.slot1_id).cooltime;
                Invoke("CoolEnd", SkillDataManager.LoadData(InventoryManager.slot1_id).cooltime);
                Debug.Log(Skills[SkillDataManager.LoadData(InventoryManager.slot1_id).arrNum]);
                skill = Instantiate(Skills[SkillDataManager.LoadData(InventoryManager.slot1_id).arrNum]);
                var info = skill.GetComponent<SkillInfoInterface>();
                info.atkCon = this;
                if (InventoryManager.slot1_id < 304)
                {
                    skill.transform.SetParent(transform, false);
                }
            }
  
            
        }
        
    }
    void CoolEnd()
    {
        isCoolTime = true;
        Debug.Log("cancel");
    }

    public void WeaponSwitch(uint itemid)
    {
        for (int i = 0; i < Swords.Length; i++) 
        {
            Swords[i].SetActive(false);
        }
        for (int i = 0; i < Wands.Length; i++)
        {
            Bows[i].SetActive(false);
        }
        for (int i = 0; i < Bows.Length; i++)
        {
            Wands[i].SetActive(false);
        }

        if (itemid / 100 == 3)
        {
            battlestate = weapon.Sword;
        }
        if (itemid / 100 == 4)
        {
            battlestate = weapon.Bow;
        }
        if (itemid / 100 == 5)
        {
            battlestate = weapon.Wand;
        }

        uint id = (itemid % 100) - 1;

        switch (battlestate)
        {
            case weapon.Sword:
                Swords[id].SetActive(true);
                arrow.SetActive(false);
                anim.runtimeAnimatorController = AOC_Sword;
                CancelInvoke("CoolEnd");
                isCoolTime = true;
                break;
            case weapon.Bow:
                Bows[id].SetActive(true);
                arrow.SetActive(true);
                anim.runtimeAnimatorController = AOC_Bow;
                CancelInvoke("CoolEnd");
                isCoolTime = true;
                break;
            case weapon.Wand:
                Wands[id].SetActive(true);
                arrow.SetActive(false);
                anim.runtimeAnimatorController = AOC_Wand;
                CancelInvoke("CoolEnd");
                isCoolTime = true;
                break;
            default:
                break;
        }




    }

    void SelectAttack()
    {
        switch (state)
        {
            case AttackState.Combo01:
                if (canCombo == true)
                {
                    canCombo = false;
                    isAttacking = false;
                }
                isAttacking = false;
                anim.CrossFade("Attack01", 0.1f);
                if (battlestate == weapon.Bow)
                {
                    Bowanim.CrossFade("Attack01", 0.1f);
                    Arrowanim.CrossFade("Attack01", 0.1f);
                }
                state = AttackState.Combo02;
                break;
            case AttackState.Combo02:
                if (canCombo == true)
                {
                    canCombo = false;
                    isAttacking = false;
                }
                isAttacking = false;
                anim.CrossFade("Attack02", 0.02f);
                if (battlestate == weapon.Bow)
                {
                    Bowanim.CrossFade("Attack01", 0.02f);
                    Arrowanim.CrossFade("Attack01", 0.02f);
                }
                state = AttackState.Combo03;
                break; 
            case AttackState.Combo03:
                
                
                if (canCombo == true)
                {
                    
                    canCombo = false;
                    isAttacking = false;
                }
                isAttacking = false;
                anim.CrossFade("Attack03", 0.01f);
                if (InventoryManager.slot1_id == 305)
                {
                    TripleShot();
                }
                if (battlestate == weapon.Bow)
                {
                    Bowanim.CrossFade("Attack02", 0.02f);
                    Arrowanim.CrossFade("Attack02", 0.02f);
                }
                state = AttackState.Combo01;
                break;
            default:
                break;
        }
    }

    public void StartDamage()
    {
        switch (battlestate)
        {
            case weapon.Sword:
                MeleeAtackLoop.SetActive(true);
                break;
            case weapon.Bow:
                break;
            case weapon.Wand:
                break;
            default:
                break;
        }
    }

    public void EndDamage()
    {
        MeleeAtackLoop.SetActive(false);
    }

    public void AttackEnd()
    {
        state = AttackState.Combo01;
        isAttacking = false;
        canCombo = false;
        anim.SetBool("isAttack", canCombo);
    }
}

