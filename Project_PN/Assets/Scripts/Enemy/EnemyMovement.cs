using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;

    public Animator anim;

    enum State
    {
        Idle,
        Run,
        Attack
    }

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        agent.destination = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Run)
        {
            UpdateRun();

        }
        else if (state == State.Attack)
        {
            UpdateAttack();
        }
    }

    private void UpdateAttack()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isAttack", true);
        agent.speed = 0;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 2)
        {
            state = State.Run;
            anim.SetTrigger("Run");
        }
    }

    private void UpdateRun()
    {
        anim.SetBool("isRun", true);
        anim.SetBool("isAttack", false);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 2)
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }
        agent.speed = 3.5f;
        agent.destination = target.transform.position;
    }

    private void UpdateIdle()
    {
        anim.SetBool("isRun", false);
        anim.SetBool("isAttack", false);
        agent.speed = 0;
        target = GameObject.Find("Player").transform;
        if (target != null)
        {
            state = State.Run;
        }
    }
}
