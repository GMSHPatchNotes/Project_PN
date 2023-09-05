using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_04_02 : MonoBehaviour
{
    int SkillDamage;
    void Start()
    {
        SkillDamage = (int)ItemDataManager.LoadData(InventoryManager.slot1_id).ap;
        Invoke("End", 0.4f);
    }
    
    void End()
    {
        PlayerMovement.SkillUsing = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(enemy)
        {
            enemy.TakeDamage(SkillDamage,false);
        }
    }
}
