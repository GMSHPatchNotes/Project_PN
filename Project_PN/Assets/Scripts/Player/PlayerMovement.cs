using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region
    //[SerializeField] private float moveSpeed = 0; //CharacterMoveSpeed

    //private Vector3 Dir; //Character Input Value
    #endregion
    [SerializeField] private float MoveSpeed = 0;

    private Vector3 Dir;

    
    
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
         
            Dir.x = Input.GetAxis("Horizontal");
            Dir.z = Input.GetAxis("Vertical");

            Dir.Normalize();

            transform.position += Dir * MoveSpeed * Time.deltaTime;
        
    }

    

   
    #region
    //void Move() //Character Move Control
    //{
    //    Dir.x = Input.GetAxis("Horizontal");
    //    Dir.z = Input.GetAxis("Vertical");

    //    Dir.Normalize();

    //    transform.position += Dir * moveSpeed * Time.deltaTime;
    //}

    #endregion
}
