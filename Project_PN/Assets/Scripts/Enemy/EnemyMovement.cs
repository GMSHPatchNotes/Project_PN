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

    public Rigidbody rb;

    NavMeshAgent agent;


    [SerializeField] public Material[] mat = new Material[2];
    [SerializeField] public SkinnedMeshRenderer mesh;

    public Animator anim;

    public bool CanMove = true;

    public bool isAttacking;

    public bool isstun;

    enum State
    {
        Idle,
        Run,
        Attack
    }

    State state;

    // Start is called before the first frame update


    public IEnumerator Stun()
    {
        isstun = true;
        Debug.Log("stun");
        yield return new WaitForSeconds(3f);
        isstun = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if(!isstun)
        {
            
            Debug.Log(state);
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
        
    }

    private void UpdateAttack()
    {
        if (!isAttacking)
        {
            agent.SetDestination(transform.position);
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance > 2 && CanMove)
            {
                anim.SetBool("isRun", true);
                anim.SetBool("isAttack", false);
                state = State.Run;
            }
        }
    }

    public void TakeDamage(int Damage)
    {
        Debug.Log(Damage);
        //agent.enabled = false;
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.forward * -5, ForceMode.Impulse);
        mesh.material = mat[1];
        anim.CrossFade("Hit", 0.1f);
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
            Debug.Log("setidle");
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
            Debug.Log("idlefuck");
            state = State.Run;
            anim.SetBool("isRun", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
