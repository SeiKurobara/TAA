using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class stg21EnemyController : MonoBehaviour
{
    private NavMeshAgent enemyNavMeshAGent;
    private Animator enemyAnimator;

    public Transform playerTransform;
    public bool playerInDetectionRange = false;
    public stg21HealthManager pHealth;
    public GameObject detectionFight;

    private int maxHealth;
    private int currentHealth;



    // Awake is called before the first frame update
    void Awake()
    {
        enemyNavMeshAGent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (playerInDetectionRange == true)    
        {
            if (currentHealth <= 0)
            {
                enemyNavMeshAGent.transform.LookAt(playerTransform);
                Idle();
                detectionFight.SetActive(true);

            } else

            {
                enemyNavMeshAGent.transform.LookAt(playerTransform);
                enemyNavMeshAGent.SetDestination(playerTransform.position + new Vector3(0,0,0.099f));
            }

            
        }
    }

    public void Idle()
    {
        enemyNavMeshAGent.speed = 0f;
        enemyAnimator.SetTrigger("Idle");
    }

    public void Walk()
    {
        enemyNavMeshAGent.speed = 1f;
        enemyAnimator.SetTrigger("Walk");
    }


    public void Run()
    {
        enemyNavMeshAGent.speed = 0.4f;
        enemyAnimator.SetTrigger("Run");
    }

    public void Attack()
    {
        enemyAnimator.SetTrigger("Attack");
    }

}
