using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stg12HurtPlayer : MonoBehaviour
{

    public int damageToGive = 1;
    public int scoreDecrease = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<stg12HealthManager>().HurtPlayer(damageToGive, hitDirection);
            FindObjectOfType<stg12Score>().Stg12ScorePointDecrease(scoreDecrease);

        }
    }
}
