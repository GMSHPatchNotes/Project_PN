using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
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
    [SerializeField] CapsuleCollider col;

    [Header("CoolTime Images")]
    [SerializeField] Image CoolTime_img;
    [SerializeField] Text CoolTime_Text;
    public static float WeaponChangeCoolTime = 0f;

    public static bool WeaponChanging = false;
    const int comboAttackLimit = 4; // player can combo Attack affter first attack

    public bool canMove ; //player can move
    public bool canComboAttack; // player can comboattack

    public static bool SkillUsing = false;

    private Vector3 Dir;
    private Vector3 CurPointPos;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
    }

    void Start()
    {
        canMove = true;
    }

   
    public void TakeDamage(int Damage, bool knockback)
    {
        Stats.Health -= Damage;
        playerAnim.CrossFade("GetHit01", 0.1f);
    }
    void Update()
    {
        if(WeaponChanging && WeaponChangeCoolTime >= 0f)
        {
            WeaponChangeCoolTime -= Time.deltaTime;
            CoolTime_Text.text = WeaponChangeCoolTime.ToString("F1");
            CoolTime_img.fillAmount = WeaponChangeCoolTime / 4;
        }
        else
        {
            CoolTime_img.fillAmount = 0;
            CoolTime_Text.text = "";
            WeaponChanging = false;
        }
        WeaponChange();
        if (Input.GetMouseButtonDown(0))
        {
            AttackClick(false);
        }
        
        if (!atkCon.isAttacking)
        {
            Move();
            if(!SkillUsing && !WeaponChanging)
            {
                
                
                if (Input.GetKeyDown(KeyCode.F) && InventoryManager.slot2_id != 0)
                {
                    WeaponChangeCoolTime = 4f;
                    WeaponChanging = true;
                    //PlayerAttackControl.isCoolTime = true;
                    Debug.Log("Switching");
                    atkCon.WeaponSwitch(InventoryManager.slot1_id);
                }
            }
            
           
            if (Input.GetKeyDown(KeyCode.Q) && InventoryManager.slot1_id != 301)
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

        if (Physics.Raycast(ray, out hit, 1000))
        {
            CurPointPos = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
            
        }
        return Physics.Raycast(ray, out hit, 1000);
    }

    void WeaponChange()
    {

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            InventoryManager.slot2_id = 302;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();
            
            W_Slot2.W2_ReloadInfoData();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            InventoryManager.slot2_id = 303;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            InventoryManager.slot2_id = 304;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            InventoryManager.slot2_id = 305;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
        /*if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            InventoryManager.slot2_id = 401;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }*/
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            InventoryManager.slot2_id = 501;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            InventoryManager.slot2_id = 502;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            InventoryManager.slot2_id = 503;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            InventoryManager.slot2_id = 504;
            W_Slot2.W2_ReloadID();
            W_Slot2.W2_ReloadData();

            W_Slot2.W2_ReloadInfoData();
        }
    }

    public Vector3 AttackClick(bool isSkill)
    {
        if (CalCurMousePos())
        {

            player.transform.LookAt(CurPointPos);

                 
            if (isSkill)
            {
                return new Vector3(CurPointPos.x,CurPointPos.y - 1.493818f,CurPointPos.z);
            }
            else
            {
                atkCon.AttackStart();
            }

            return Vector3.zero;
        }
        return Vector3.zero;
    }

    //void Hurt()
    //{
    //    Stats.Health -= 10f;
    //}
    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if(enemy)
        {
            //Invoke("Hurt", 0.5f);
        }
    }



}




