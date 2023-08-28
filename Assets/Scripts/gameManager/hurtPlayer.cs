using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour
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
            FindObjectOfType<healthManager>().HurtPlayer(damageToGive, hitDirection);
            FindObjectOfType<stg11Score>().Stg11ScorePointDecrease(scoreDecrease);

        }
    }
}
