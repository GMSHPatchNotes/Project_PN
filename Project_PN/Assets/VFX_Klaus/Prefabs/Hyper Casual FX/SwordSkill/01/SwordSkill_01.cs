using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_01 : MonoBehaviour
{
    //PlayerAttackControl attackControl;

    EnemyMovement enemy;

    SkillInfoInterface Info;

    void Start()
    {
        //transform.parent = attackControl.transform;
        Info = GetComponent<SkillInfoInterface>();
        StartCoroutine("Damage");
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
                enemy.TakeDamage(10, true);
            }
            yield return new WaitForSeconds(0.5f);
            Check++;
            if (Check == 12)
            {
                Info.atkCon.anim.SetBool("AttackEnd", true);
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
