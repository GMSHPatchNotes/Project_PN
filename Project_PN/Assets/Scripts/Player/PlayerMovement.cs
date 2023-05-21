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
    [SerializeField] private Transform player;
    [SerializeField] private Animator playerAnim;

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
        
        if (Dir.x != 0 || Dir.z != 0) //플레이어가 움직이고있니?
        {
            playerAnim.SetBool("isMove", true);
            player.transform.localRotation = Quaternion.LookRotation(Dir);
        }
        else
        {
            playerAnim.SetBool("isMove", false);
        }

        Debug.Log(Dir);

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
