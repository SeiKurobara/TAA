using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    public float range = 5;
    public GameObject findThesePanel;


     void Update()
    {
        Vector3 direction = Vector3.forward;

        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));


        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Door")
            {
                print("Its a Door");
               
                findThesePanel.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
            }
            else
            {
              
                print("Its not a door");

                findThesePanel.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }
        }
    }

}
