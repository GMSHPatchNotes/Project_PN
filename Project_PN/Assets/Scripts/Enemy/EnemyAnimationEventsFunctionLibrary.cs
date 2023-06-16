using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventsFunctionLibrary : MonoBehaviour
{
    private Animator EnemyAnim;
    [SerializeField] private EnemyMovement animator;

    
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
