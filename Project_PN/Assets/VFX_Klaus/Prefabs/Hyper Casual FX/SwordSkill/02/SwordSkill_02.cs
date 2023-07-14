using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy)
        {
            enemy.TakeDamage(10);
        }
    }
}
