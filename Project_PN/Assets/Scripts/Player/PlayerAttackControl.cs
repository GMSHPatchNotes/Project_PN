using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AttackState
{
    Combo01,
    Combo02,
    Combo03,
}

public class PlayerAttackControl : MonoBehaviour
{

    [SerializeField] private Animator anim;

    AttackState state = AttackState.Combo01;

    public bool isAttacking = false;
    public bool canCombo = false;

    public void AttackStart()
    {

        if (!isAttacking)
        {
            Debug.Log(canCombo);
            canCombo = false;
            isAttacking = true;
            SelectAttack();
        }
        else if (isAttacking && canCombo)
        {
            Debug.Log(canCombo);
            canCombo = false;
            isAttacking = true;
            SelectAttack();
        }
    }

    void SelectAttack()
    {
        switch(state)
        {
            case AttackState.Combo01:
                anim.CrossFade("Attack01", 0.1f);
                canCombo = false;
                isAttacking = true;
                state = AttackState.Combo02;
                break;
            case AttackState.Combo02:
                anim.CrossFade("Attack02", 0.01f);
                canCombo = false;
                isAttacking = true;
                state = AttackState.Combo03;
                break; 
            case AttackState.Combo03:
                anim.CrossFade("Attack03", 0.01f);
                canCombo = false;
                isAttacking = true;
                state = AttackState.Combo01;
                break;
            default:
                break;
        }
    }

    void ApplyDamage()
    {
        
    }

    public void AttackEnd()
    {
        state = AttackState.Combo01;
        isAttacking = false;
        canCombo = false;
    }
}
