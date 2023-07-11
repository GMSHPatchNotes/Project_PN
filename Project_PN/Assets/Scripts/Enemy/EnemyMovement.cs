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

    public bool CanMove = true;

    public bool isAttacking;

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
        if (target != null)
        {
            agent.destination = target.transform.position;
        }
    }

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
        if (!isAttacking)
        {
            agent.SetDestination(transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance > 2 && CanMove)
            {
                Debug.Log("aa");
                anim.SetBool("isRun", true);
                anim.SetBool("isAttack", false);
                state = State.Run;
            }
        }
    }

    private void UpdateRun()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= 2)
        {
            anim.SetBool("isAttack", true);
            anim.SetBool("isRun", false);
            state = State.Attack;
        }
        else if(distance >= 10)
        {
            anim.SetBool("isRun", false);
            state = State.Idle;
        }
        agent.SetDestination(target.transform.position);
    }

    private void UpdateIdle()
    {
        agent.SetDestination(transform.position);
        target = GameObject.Find("Player").transform;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (target != null && distance <= 10)
        {
            state = State.Run;
            anim.SetBool("isRun", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
