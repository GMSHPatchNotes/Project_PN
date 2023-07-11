using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private PlayerAttackControl atkCon;

    void Start()
    {
        playerAnim = GetComponent<Animator>();   
    }

    public void CanCombo()
    {
        atkCon.canCombo = true;
    }

    public void AttackEnd()
    {
        atkCon.AttackEnd();
        //player.canMove = true;
        //playerAnim.SetBool("isAttack", false);
    }

    public void SecondsAttackEnd()
    {
        //player.canMove = true;
        //player.canComboAttack = false;
        //playerAnim.SetBool("isAttack", false);
        //playerAnim.SetBool("isSecondsAttack", false);
    }
   
    public void attackEnable(int isenable)
    {
        //if (isenable == 1)
        //{
        //    boxCollider.enabled = true;
        //}
        //else
        //{
        //    boxCollider.enabled = false;
        //}
    }


    //void Update()
    //{

    //}





}
