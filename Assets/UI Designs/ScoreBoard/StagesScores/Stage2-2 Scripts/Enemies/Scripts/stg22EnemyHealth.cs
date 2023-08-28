using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stg22EnemyHealth : MonoBehaviour
{
    public float fullHealth;
    public float currentHealth;
    public bool enemyDied = false;

    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;
    public int enemyPlusScoreWhenDead;
    public GameObject enemyDeathEffect;
    public GameObject enemySilverStars;
    public Transform enemy;
    public Transform starSpawn;


    // Awake is called before the first frame update
    void Awake()
    {
        currentHealth = fullHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = fullHealth;
        enemyHealthSlider.value = currentHealth;

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            enemyDied = true;
            MakeDied();
            FindObjectOfType<stg22Score>().Stg22ScorePointIncrease(enemyPlusScoreWhenDead);
            Instantiate(enemyDeathEffect, enemy.transform.position, enemy.transform.rotation);
            Instantiate(enemySilverStars, starSpawn.transform.position, starSpawn.transform.rotation);
        }
    }

    public void MakeDied()
    {
        Destroy(gameObject);
    }

}
