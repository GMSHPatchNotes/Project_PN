using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player)
        {
            player.TakeDamage(10, true);
            Debug.Log("aa");
            PlayerAttackControl.lifeSteal(InventoryManager.slot1_id, 6);
        }
    }
}
