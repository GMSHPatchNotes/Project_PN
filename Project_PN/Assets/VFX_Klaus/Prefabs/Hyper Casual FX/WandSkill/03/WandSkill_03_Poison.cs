using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_03_Poison : MonoBehaviour
{
   
    void Start()
    {
        
        TickDamage();
        Destroy(this.gameObject,5f);
    }

   
    void TickDamage()
    {
        EnemyMovement enemy = GetComponentInParent<EnemyMovement>();
        Debug.Log($"Tick Damage : {enemy}");
        enemy.TakeDamage(20,false);
        Invoke("TickDamage", 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(enemy && enemy.ispoison)
        {
            Debug.Log("Àü¿°");
            Instantiate(this.gameObject, enemy.transform);
            enemy.ispoison = true;
        }
            
            
        
    }
}
