using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public bool isDetect ;
    // Start is called before the first frame update
    void Start()
    {
        isDetect = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            isDetect = true;
        }
    }
}
