using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector3 start;
    private float distance = 0;
    
    public void ResetPos()
    {
        start = transform.position;
    }


    void Update()
    {
        distance = Vector3.Distance(transform.position, start);
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
        if (distance > 25)
        {
            
            Debug.Log("destroy");
            this.gameObject.SetActive(false);
        }

    }

    

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy)
        {
            enemy.TakeDamage(10);
            
            this.gameObject.SetActive(false);
        }
    }
}
