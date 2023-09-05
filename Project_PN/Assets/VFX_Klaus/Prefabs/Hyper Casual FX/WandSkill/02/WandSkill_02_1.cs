using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_02_1 : MonoBehaviour
{
    int SkillDamage;
    void Start()
    {
        SkillDamage = (int)ItemDataManager.LoadData(InventoryManager.slot1_id).ap;
        Destroy(this.gameObject, 0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if(enemy)
        {
            enemy.TakeDamage(SkillDamage, false);
        }
    }

    

}
