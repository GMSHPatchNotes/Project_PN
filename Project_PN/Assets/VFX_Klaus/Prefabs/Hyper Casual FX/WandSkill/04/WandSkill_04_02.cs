using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_04_02 : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(enemy)
        {
            enemy.TakeDamage(100,false);
        }
    }
}
