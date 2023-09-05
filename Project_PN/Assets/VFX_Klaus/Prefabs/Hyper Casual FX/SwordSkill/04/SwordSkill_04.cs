using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_04 : MonoBehaviour
{

    int SkillDamage;

    bool cool = false;
    SkillInfoInterface Info;
    void Start()
    {
        Info = GetComponent<SkillInfoInterface>();
        Info.MousePos = Info.atkCon.movement.AttackClick(true);

        transform.rotation = Info.atkCon.player.transform.rotation;
        transform.position = Info.atkCon.transform.position + Info.atkCon.player.transform.forward * 3f;
        //Info.atkCon.player.transform.LookAt(Info.MousePos);
        Info.atkCon.anim.CrossFade("Attack02", 0.1f);
        SkillDamage = (int)ItemDataManager.LoadData(InventoryManager.slot1_id).ad;
        Invoke("End", 5f);
    }

    void End()
    {
        PlayerMovement.SkillUsing = false;
        Destroy(this.gameObject);
    }

    void Update()
    {

    }

    void CoolTime()
    {
        cool = false;
    }

    private void OnTriggerStay(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy && !cool)
        {
            cool = true;
            enemy.TakeDamage(SkillDamage, false);
            Invoke("CoolTime", 0.5f);
        }
    }
}
