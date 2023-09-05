using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_03 : MonoBehaviour
{
    int SkillDamage = 20;

    SkillInfoInterface Info;
    void Start()
    {
        Info = GetComponent<SkillInfoInterface>();
        Info.MousePos = Info.atkCon.movement.AttackClick(true);

        transform.rotation = Info.atkCon.player.transform.rotation;
        transform.position = Info.atkCon.transform.position + Info.atkCon.player.transform.forward * 3f;
        //Info.atkCon.player.transform.LookAt(Info.MousePos);
        Info.atkCon.anim.CrossFade("Attack02", 0.1f);
        Invoke("End", 0.5f);

    }

    void End()
    {
        PlayerMovement.SkillUsing = false;
        Destroy(this.gameObject);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(enemy)
        {
            enemy.TakeDamage(SkillDamage,true);
        }
    }
}
