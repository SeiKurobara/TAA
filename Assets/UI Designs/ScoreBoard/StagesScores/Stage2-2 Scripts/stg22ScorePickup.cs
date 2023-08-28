using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stg22ScorePickup : MonoBehaviour
{
    public int scoreValue;
    public GameObject PickupEffects;

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
        if (other.tag == "Player")
        {
            FindObjectOfType<stg22Score>().Stg22ScorePointIncrease(scoreValue);


            Instantiate(PickupEffects, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("ScorePickedUp");
        }
    }
}
