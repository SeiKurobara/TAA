using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class stg11CheckPoint : MonoBehaviour
{

    public stg11HealthManager theHealthMan;
    public Renderer theRend;
    public Material cpOff;
    public Material cpOn;


    // Start is called before the first frame update
    void Start()
    {
        theHealthMan = FindObjectOfType<stg11HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void checkPointOff()
    {
        theRend.material = cpOff;
    }

    public void checkPointOn()
    {
        CheckPoint[] checkpoints = FindObjectsOfType<CheckPoint>();

        foreach (CheckPoint cp in checkpoints)
        {
            cp.checkPointOff();
        }
        theRend.material = cpOn;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            theHealthMan.SetSpawnPoint(transform.position);
            checkPointOn();
        }
    }
}
