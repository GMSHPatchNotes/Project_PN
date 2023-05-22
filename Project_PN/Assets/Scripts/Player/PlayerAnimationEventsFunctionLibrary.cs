using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();   
    }

    public void AttackEnd()
    {
        playerAnim.SetBool("isAttack", false);
    }


    //void Update()
    //{
        
    //}





}
