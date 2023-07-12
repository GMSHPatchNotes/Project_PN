using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField] private PlayerMovement player;
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
    }

    public void Dash(int Distance)
    {
        player.Dash(Distance);
    }
    public void AttackEnable()
    {
        atkCon.StartDamage();
    }

    public void AttackDisable()
    {
        atkCon.EndDamage();
    }






}
