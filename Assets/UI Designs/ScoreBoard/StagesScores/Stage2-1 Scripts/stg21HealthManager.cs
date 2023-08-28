using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class stg21HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public PlayerMovement thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRendererHead, playerRendererTorso, playerRendererPants;
    public float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;

    //healthBar
    public stg21FillStatusBar healthBar;

    public TextMeshProUGUI seeCurrentHealth;

    public AudioClip deathAudio;
    public AudioClip hitAudio;
    public AudioClip healAudio;
    public Transform PlayerAudio;


    public int scoreDecreasebyTen = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //thePlayer = FindObjectOfType<PlayerMovement>();


        respawnPoint = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        HealthBarNumbers();
        if (invincibilityCounter > 0)
        {

            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0)
            {
                playerRendererHead.enabled = !playerRendererHead.enabled;
                playerRendererTorso.enabled = !playerRendererTorso.enabled;
                playerRendererPants.enabled = !playerRendererPants.enabled;
                flashCounter = flashLength;
            }
            if (invincibilityCounter <= 0)
            {
                playerRendererHead.enabled = true;
                playerRendererTorso.enabled = true;
                playerRendererPants.enabled = true;
            }
        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }
        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
    }

    public void HealthBarNumbers()
    {
        seeCurrentHealth.text = currentHealth + "/" + maxHealth;
    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            AudioSource.PlayClipAtPoint(hitAudio, PlayerAudio.transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);


            if (currentHealth <= 0)
            {

                AudioSource.PlayClipAtPoint(deathAudio, PlayerAudio.transform.position);
                Respawn();
                FindObjectOfType<stg21Score>().Stg21ScorePointDecrease(scoreDecreasebyTen);
            }
            else
            {


                //
                invincibilityCounter = invincibilityLength;
                //
                playerRendererHead.enabled = false;
                playerRendererTorso.enabled = false;
                playerRendererPants.enabled = false;
                //
                flashCounter = flashLength;
                //
            }
        }

    }

    public void Respawn()
    {
        /* thePlayer.characterController.enabled = false;
         thePlayer.transform.position = respawnPoint;
         thePlayer.characterController.enabled = true;
         currentHealth = maxHealth;
        */
        if (!isRespawning)
        {

            StartCoroutine("respawnCo");

        }

    }

    public IEnumerator respawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);


        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;

        isRespawning = false;

        thePlayer.gameObject.SetActive(true);

        thePlayer.characterController.enabled = false;
        thePlayer.transform.position = respawnPoint;
        thePlayer.characterController.enabled = true;
        currentHealth = maxHealth;

        //
        invincibilityCounter = invincibilityLength;
        //
        playerRendererHead.enabled = false;
        playerRendererTorso.enabled = false;
        playerRendererPants.enabled = false;
        //
        flashCounter = flashLength;

        //
        healthBar.SetHealth(maxHealth);

    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        AudioSource.PlayClipAtPoint(healAudio, PlayerAudio.transform.position);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;

        }
        healthBar.SetHealth(currentHealth);
        Debug.Log("Healssssss");
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }


}
