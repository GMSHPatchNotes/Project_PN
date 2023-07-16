using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_03 : MonoBehaviour
{
    [SerializeField] GameObject poison;
    // Start is called before the first frame update
    SkillInfoInterface info;


    SphereCollider col;

    void Start()
    {

        col = GetComponent<SphereCollider>();
        info = GetComponent<SkillInfoInterface>();
        info.MousePos = info.atkCon.movement.AttackClick(true);

        //transform.rotation = info.atkCon.player.transform.rotation;
        this.transform.position = info.MousePos;

        Destroy(this.gameObject, 5.5f);
    }


     

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if (enemy && !enemy.ispoison)
        {
            Instantiate(poison, enemy.transform);
            enemy.ispoison = true;
        }
    }

    
}
