using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSkill_02 : MonoBehaviour
{
    SkillInfoInterface info;
    [SerializeField] GameObject WaterDrop;

    BoxCollider boxCol;

    bool cool = true;
    private void Awake()
    {
        boxCol = GetComponent<BoxCollider>();
        
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = transform.position;
        float range_X = boxCol.bounds.size.x;
        float range_Z = boxCol.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;
    }
    void Start()
    {
        info = GetComponent<SkillInfoInterface>();
        info.MousePos = info.atkCon.movement.AttackClick(true);
        this.transform.rotation = info.atkCon.player.transform.rotation;
        this.transform.position = info.atkCon.transform.position + info.atkCon.player.transform.forward * 5f;
        StartCoroutine(RandomRespawn_Coroutine());
        Invoke("EndSkill", 7f);
    }

    void Update()
    {
        
    }

    void EndSkill()
    {
        cool = false;
        Destroy(this.gameObject, 0.4f);
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while(cool)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));

            Instantiate(WaterDrop, Return_RandomPosition(), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if(enemy)
        {
            enemy.agent.speed = 1.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if(enemy)
        {
            enemy.agent.speed = 3f;
            enemy = null;
        }
    }
}
