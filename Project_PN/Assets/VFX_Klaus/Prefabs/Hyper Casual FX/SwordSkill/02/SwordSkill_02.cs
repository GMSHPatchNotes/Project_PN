using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill_02 : MonoBehaviour
{
    EnemyMovement enemy;

    SkillInfoInterface Info;

    Rigidbody rb;

    int SkillDamage;
    private void Start()
    {
        Info = GetComponent<SkillInfoInterface>();
        rb = Info.atkCon.gameObject.GetComponent<Rigidbody>();
        transform.position += new Vector3(0, 0.7f, 0);
        Info.MousePos = Info.atkCon.movement.AttackClick(true);
        transform.rotation = Info.atkCon.player.transform.rotation;
        //Info.atkCon.player.transform.LookAt(Info.MousePos);
        Info.atkCon.anim.CrossFade("Attack02", 0.1f);
        StartCoroutine(End());
        rb.velocity = Vector3.zero;
        SkillDamage = (int)ItemDataManager.LoadData(InventoryManager.slot1_id).ad;
        rb.AddForce(Info.atkCon.player.transform.forward * 50, ForceMode.Impulse);
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(0.3f);

        rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(0.2f);
        PlayerMovement.SkillUsing = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy)
        {
            enemy.TakeDamage(SkillDamage, true);
        }
    }
}
