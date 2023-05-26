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
    private Vector3 CurPointPos;

    
    
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
         
        Dir.x = Input.GetAxis("Horizontal");
        Dir.z = Input.GetAxis("Vertical");

        Dir.Normalize();
        
        if (Dir.x != 0 || Dir.z != 0) //
        {
            playerAnim.SetBool("isMove", true);
            player.transform.localRotation = Quaternion.LookRotation(Dir);
        }
        else
        {
            playerAnim.SetBool("isMove", false);
        }

        transform.position += Dir * MoveSpeed * Time.deltaTime;
    }

    void Attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            CurPointPos = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);

            if (Input.GetMouseButtonDown(0))
            {
                player.transform.LookAt(CurPointPos);
                playerAnim.SetBool("isAttack", true);
            }
        }
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
