using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy)
        {
            enemy.TakeDamage(10,true);
            PlayerAttackControl.lifeSteal(InventoryManager.slot1_id,6);
        }
    }
}
