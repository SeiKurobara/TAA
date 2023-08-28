using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform cam;
   
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.rotation *- Vector3.back, cam.transform.rotation *- Vector3.down);
    }
}
