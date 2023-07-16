using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSkill_01_Arrow : MonoBehaviour
{
    SkillInfoInterface info;
    [SerializeField] GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
        info = GetComponent<SkillInfoInterface>();
        info.MousePos = info.atkCon.movement.AttackClick(true);
        transform.rotation = info.atkCon.player.transform.rotation;
        transform.position = info.atkCon.transform.position + info.atkCon.player.transform.forward;
        ResetPos();
        info.atkCon.anim.CrossFade("Attack01", 0.1f);
        info.atkCon.Bowanim.CrossFade("Attack01", 0.02f);
        info.atkCon.Arrowanim.CrossFade("Attack01", 0.02f);
        //Destroy(this.gameObject, 0.4f);
    }


    Vector3 start;
    private float distance = 0;

    public void ResetPos()
    {
        start = info.atkCon.player.transform.position;
    }


    void Update()
    {
        distance = Vector3.Distance(this.transform.position, start);
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
        if (distance > 25)
        {
            Destroy(this.gameObject);
            
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy)
        {
            enemy.TakeDamage(10, false);
            enemy.Stun();
            Instantiate(effect, this.transform.position + Vector3.up, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


}
