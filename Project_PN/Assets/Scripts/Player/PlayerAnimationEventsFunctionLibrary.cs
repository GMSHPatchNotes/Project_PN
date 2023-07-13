using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerAttackControl atkCon;
    [SerializeField] private AudioSource As;
    [SerializeField] private AudioClip[] attackSound = new AudioClip[3];

    void Start()
    {
        playerAnim = GetComponent<Animator>();   
    }

    public void StartAttack()
    {
        atkCon.isAttacking = true;
        int random = Random.Range(0, 2);
        As.clip = attackSound[random];
    }

    public void PlayAttackSound()
    {
        if (!As.isPlaying)
        {
            As.Play();
        }
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
