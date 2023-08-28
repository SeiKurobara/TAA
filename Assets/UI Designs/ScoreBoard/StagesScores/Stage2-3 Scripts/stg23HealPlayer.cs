using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stg23HealPlayer : MonoBehaviour
{
    public int healToGive =20;
    
    public GameObject effects;
    public Transform effectSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<stg23HealthManager>().HealPlayer(healToGive);
            Instantiate(effects, effectSpawn.transform.position, effectSpawn.transform.rotation);
            Destroy(gameObject);
        }
           
    }
}
