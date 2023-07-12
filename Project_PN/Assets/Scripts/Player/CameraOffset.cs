using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraOffset : MonoBehaviour
{
    [SerializeField] private Transform Character;


    void Start()
    {
        
    }

    void Update()
    {
        if (Character.position.x != 0)
        {
            transform.position = new Vector3(Character.position.x, transform.position.y, transform.position.z);
            Character.position = new Vector3(0, Character.position.y, Character.position.z);
        }
        if (Character.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Character.position.z);
            Character.position = new Vector3(Character.position.x, Character.position.y, 0);
        }
    }
}
