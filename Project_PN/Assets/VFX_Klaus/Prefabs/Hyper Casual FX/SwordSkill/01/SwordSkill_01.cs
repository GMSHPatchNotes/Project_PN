using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_01 : MonoBehaviour
{
    //PlayerAttackControl attackControl;

    EnemyMovement enemy;

    SkillInfoInterface Info;

    int SkillDamage;
    void Start()
    {
        
        //transform.parent = attackControl.transform;
        Info = GetComponent<SkillInfoInterface>();
        Info.atkCon.transform.parent = transform;
        StartCoroutine("Damage");
        SkillDamage = (int)ItemDataManager.LoadData(InventoryManager.slot1_id).ad;
        transform.position += new Vector3(0, 0.7f, 0);
    }

    IEnumerator Damage()
    {
        Info.atkCon.anim.SetBool("AttackEnd", false);
        Info.atkCon.anim.CrossFade("Skill01", 0.1f);
        bool isEnd = false;

        int Check = 0;

        while (!isEnd)
        {
            if (enemy)
            {
                enemy.TakeDamage(SkillDamage, true);
            }
            yield return new WaitForSeconds(0.5f);
            Check++;
            if (Check == 12)
            {
                Info.atkCon.anim.SetBool("AttackEnd", true);
                PlayerMovement.SkillUsing = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enemy = other.GetComponent<EnemyMovement>();
        if (!other)
        {
            enemy = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!enemy)
        {
            enemy = other.GetComponent<EnemyMovement>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        enemy = other.GetComponent<EnemyMovement>();
        if (other)
        {
            enemy = null;
        }
    }
}
