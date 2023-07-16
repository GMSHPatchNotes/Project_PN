using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class WandSkill_01 : MonoBehaviour
{
    SkillInfoInterface info;

    int SkillDamage = 20;

    bool cool = false;

    float moveSpeed = 10;
    private void Start()
    {
        info = GetComponent<SkillInfoInterface>();
        info.MousePos = info.atkCon.movement.AttackClick(true);
        this.transform.rotation = info.atkCon.player.transform.rotation;
        this.transform.position = info.atkCon.transform.position + info.atkCon.player.transform.forward + Vector3.up * 1.5f;
        Destroy(this.gameObject, 6f);

    }

    private void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        Debug.Log(cool);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>(); 

            if (enemy)
            {
                moveSpeed = 3;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if (enemy)
        {
            enemy = null;
            moveSpeed = 10;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        
        if(!cool && enemy != null)
        {
            
            enemy.TakeDamage(SkillDamage,false);
            cool = true;
            Invoke("EndCoolTime", 0.5f);
        }
    }

    void EndCoolTime()
    {
        cool = false;
    }

}
