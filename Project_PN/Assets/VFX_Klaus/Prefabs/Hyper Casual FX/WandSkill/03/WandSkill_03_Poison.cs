using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_03_Poison : MonoBehaviour
{
   
    void Start()
    {
        transform.position = new Vector3(transform.position.x,0.3f, transform.position.z);
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

   /* private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if(enemy && !enemy.ispoison)
        {
            Debug.Log("Àü¿°");
            Instantiate(this.gameObject, enemy.transform);
            enemy.Poison();
        }
            
            
        
    }*/

    private void OnTriggerStay(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy && !enemy.ispoison)
        {
            Debug.Log("Àü¿°");
            Instantiate(this.gameObject, enemy.transform);
            enemy.Poison();
        }
    }
}
