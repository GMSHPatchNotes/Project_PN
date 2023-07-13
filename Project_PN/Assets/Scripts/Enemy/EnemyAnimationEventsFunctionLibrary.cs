using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator EnemyAnim;
    [SerializeField] private EnemyMovement Enemy;

    
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
    }


    public void attackEnable()
    {
        Enemy.CanMove = true;
        Enemy.isAttacking = true;
    }

    public void AttackEnd()
    {
        Enemy.isAttacking = false;
    }
}
