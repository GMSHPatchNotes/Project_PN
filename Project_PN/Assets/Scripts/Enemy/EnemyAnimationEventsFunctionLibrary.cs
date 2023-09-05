using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator EnemyAnim;
    [SerializeField] private EnemyMovement Enemy;
    [SerializeField] private GameObject attack;

    
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitEnd()
    {
        Enemy.rb.velocity = Vector3.zero;
        Enemy.mesh.material = Enemy.mat[0];
        Debug.Log("End");
    }


    public void attackEnable()
    {
        Enemy.CanMove = true;
        Enemy.isAttacking = true;
        attack.SetActive(true);
    }

    public void AttackEnd()
    {
        Enemy.isAttacking = false;
        attack.SetActive(false);
    }
}
