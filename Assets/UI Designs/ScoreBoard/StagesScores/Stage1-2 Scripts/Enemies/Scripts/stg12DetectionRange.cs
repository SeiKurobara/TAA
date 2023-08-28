using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stg12DetectionRange : MonoBehaviour
{
    public stg12EnemyController enemyControl;


    // Awake is called before the first frame update
    void Awake()
    {
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {   
            enemyControl.Run();
            enemyControl.playerInDetectionRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemyControl.Idle();
            enemyControl.playerInDetectionRange = true;
        }
    }

     
}
