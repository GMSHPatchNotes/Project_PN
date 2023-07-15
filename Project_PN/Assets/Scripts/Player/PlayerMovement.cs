using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Build;
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
    [SerializeField] private PlayerAttackControl atkCon;
    [SerializeField] private Rigidbody rb;

    const int comboAttackLimit = 4; // player can combo Attack affter first attack

    public bool canMove ; //player can move
    public bool canComboAttack; // player can comboattack

    private Vector3 Dir;
    private Vector3 CurPointPos;

    
    
    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackClick(false);
        }
        
        if (!atkCon.isAttacking)
        {
            Move();
            if (Input.GetKeyDown(KeyCode.F))
            {
                atkCon.WeaponSwitch(303);
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                atkCon.WeaponSwitch(403);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                atkCon.Skill();
            }
        }
    }

    public void Dash(int Distance)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(player.forward * Distance, ForceMode.Impulse);
    }

    void Move()
    {
        if (canMove)
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
    }

    bool CalCurMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            CurPointPos = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
        }
        return Physics.Raycast(ray, out hit, 100);
    }

    public Vector3 AttackClick(bool isSkill)
    {
        if (CalCurMousePos())
        {
            player.transform.LookAt(CurPointPos);

                 
            if (isSkill)
            {
                return CurPointPos;
            }
            else
            {
                atkCon.AttackStart();
            }

            return Vector3.zero;
        }
        return Vector3.zero;
    }






}




