using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_04 : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    SkillInfoInterface info;

    SphereCollider col;

    bool trapactive = true;
    void Start()
    {
        
        col = GetComponent<SphereCollider>();
        info = GetComponent<SkillInfoInterface>();
        info.MousePos = info.atkCon.movement.AttackClick(true);

        //transform.rotation = info.atkCon.player.transform.rotation;
        Debug.Log(info.MousePos);
        this.transform.position = info.MousePos;
        
        Invoke("EndSkill", 6);
    }
    

    void EndSkill()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        trapactive = false;
        Destroy(this.gameObject, 0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if(enemy)
        {
            StartCoroutine(blackhole(enemy));
        }
    }

    IEnumerator blackhole(EnemyMovement enemy)
    {
        
        while (trapactive)
        {
            Vector3 dir = this.transform.position - enemy.transform.position;
            yield return new WaitForSeconds(0.05f);
            enemy.transform.position += dir * 12f * Time.deltaTime;
        }
        
    }
}
