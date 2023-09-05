using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_04_Passive : MonoBehaviour
{
    uint SkillDamage;

    SkillInfoInterface Info;
    void Start()
    {
        Info = GetComponent<SkillInfoInterface>();
        transform.rotation = Info.atkCon.player.transform.rotation;
        transform.position = Info.atkCon.transform.position + Info.atkCon.player.transform.forward * 3f;
        //Info.atkCon.player.transform.LookAt(Info.MousePos);
        Info.atkCon.anim.CrossFade("Attack02", 0.1f);
        SkillDamage = ItemDataManager.LoadData(InventoryManager.slot1_id).ad;
        Destroy(this.gameObject, 0.5f);

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy)
        {
            enemy.TakeDamage((int)SkillDamage, true);
        }
    }
}
