using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldPickup : MonoBehaviour
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
            FindObjectOfType<stg11Score>().Stg11ScorePointIncrease(scoreValue);
           
            
            Instantiate(PickupEffects, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
