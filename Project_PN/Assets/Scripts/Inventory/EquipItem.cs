using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    [SerializeField] GameObject[] slot = new GameObject[3];

    Slot slotScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Equip()
    {
        for(int i = 0; i < slot.Length; i++)
        {

        }
    }
}
