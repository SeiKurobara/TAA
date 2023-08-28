using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTheCanvasOnEnter : MonoBehaviour
{
    public GameObject TheCanvas;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            TheCanvas.SetActive(true);
       
    }
    private void OnTriggerExit(Collider other)
    {
        TheCanvas.SetActive(false);
    }
}
