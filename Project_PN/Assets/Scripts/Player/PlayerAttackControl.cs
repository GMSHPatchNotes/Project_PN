using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    [SerializeField] private Animator anim;
    [SerializeField] private Animator Bowanim;
    
    [Header("Weapons")]
    [SerializeField] private GameObject[] Swords;
    [SerializeField] private GameObject[] Bows;
    [SerializeField] private GameObject[] Wands;

    [Header("animtorOverrideController")]
    [SerializeField] private AnimatorOverrideController AOC_Sword;
    [SerializeField] private AnimatorOverrideController AOC_Bow;
    [SerializeField] private AnimatorOverrideController AOC_Wand;

    [Header("Attack Trace")]
    [SerializeField] private GameObject MeleeAtackLoop;



    AttackState state = AttackState.Combo01;

    weapon battlestate = weapon.Sword;
    
    public bool isAttacking = false;
    public bool canCombo = false;

    public void AttackStart()
    {
        if (!isAttacking)
        {
            MeleeAtackLoop.SetActive(false);
            canCombo = false;
            isAttacking = true;
            SelectAttack();
        }
        else if (isAttacking && canCombo)
        {
            MeleeAtackLoop.SetActive(false);
            canCombo = false;
            isAttacking = true;
            SelectAttack();
        }
    }

    public void WeaponSwitch(int itemid)
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

        int id = (itemid % 100) - 1;

        switch (battlestate)
        {
            case weapon.Sword:
                Swords[id].SetActive(true);
                anim.runtimeAnimatorController = AOC_Sword;
                break;
            case weapon.Bow:
                Bows[id].SetActive(true);
                anim.runtimeAnimatorController = AOC_Bow;
                break;
            case weapon.Wand:
                Wands[id].SetActive(true);
                anim.runtimeAnimatorController = AOC_Wand;
                break;
            default:
                break;
        }




    }

    void SelectAttack()
    {
        switch(state)
        {
            case AttackState.Combo01:
                anim.CrossFade("Attack01", 0.1f);
                canCombo = false;
                isAttacking = true;
                anim.SetBool("isAttack", canCombo);
                if (battlestate == weapon.Bow)
                {
                    Bowanim.CrossFade("Attack01", 0.1f);
                }
                state = AttackState.Combo02;
                break;
            case AttackState.Combo02:
                anim.CrossFade("Attack02", 0.01f);
                canCombo = false;
                isAttacking = true;
                anim.SetBool("isAttack", canCombo);
                if (battlestate == weapon.Bow)
                {
                    Bowanim.CrossFade("Attack01", 0.01f);
                }
                state = AttackState.Combo03;
                break; 
            case AttackState.Combo03:
                anim.CrossFade("Attack03", 0.01f);
                canCombo = false;
                isAttacking = true;
                anim.SetBool("isAttack", canCombo);
                if (battlestate == weapon.Bow)
                {
                    Bowanim.CrossFade("Attack02", 0.01f);
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

