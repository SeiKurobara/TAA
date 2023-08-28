using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stg21ScorePickup : MonoBehaviour
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
            FindObjectOfType<stg21Score>().Stg21ScorePointIncrease(scoreValue);


            Instantiate(PickupEffects, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("ScorePickedUp");
        }
    }
}
