using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator playerAnim;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Transform Character;
    [SerializeField] private PlayerAttackControl atkCon;
    [SerializeField] private AudioSource As;
    [SerializeField] private AudioClip[] attackSound = new AudioClip[3];
    [SerializeField] private Transform arrowPos;

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

    public void ArrowFire()
    {
        GameObject arrow = ArrowPool.instance.GetPooledObject();
        Arrow csarrow = arrow.GetComponent<Arrow>();
        
        if (arrow != null)
        {
            arrow.SetActive(true);
            arrow.transform.position = arrowPos.position;
            arrow.transform.rotation = Character.transform.rotation;
            csarrow.ResetPos();
        }
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
