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
        Enemy.CanMove = false;
    }

    public void attackEnable()
    {
        Enemy.CanMove = true;
    }

    public void AttackEnd()
    {

    }
}
