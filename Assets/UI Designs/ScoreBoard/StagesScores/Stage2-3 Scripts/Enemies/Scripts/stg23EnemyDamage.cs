using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class stg23EnemyDamage : MonoBehaviour
{
    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyInFightRange = false;
    public float attackCooldown = 1.4f;

    private Animator animator;

    public GameObject enemyObj;


    // Awake is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
       
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0)
        {
            attackCooldown = 0;
        }
        Debug.Log("attackCooldown" + attackCooldown);

        if (enemyInFightRange == true)
        {
            StartCoroutine(TimeDelay());
            DamageEnemy();
        }

        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyObj = other.gameObject;
            enemyInFightRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyInFightRange = false;
        }
    }

    public void DamageEnemy()
    {
       
        if (attackCooldown.Equals(0))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               
                if (nextDamage <= DateTime.Now)
                {
                    if (enemyObj.GetComponent<stg23EnemyHealth>().enemyDied == false)
                    {
                        StartCoroutine(TimeDelay());
                        enemyObj.GetComponent<stg23EnemyHealth>().AddDamage(enemyDamageAmount);
                        attackCooldown = 1.4f;
                        Debug.Log("Enemy Hit");

                    }

                   // nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
                }
            }
        }
        
       
    }

   
    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);
    }


}
