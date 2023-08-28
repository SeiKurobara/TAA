using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogTrigger trigger;
    public DialogManager dManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        dManager.ExitDialog();
    }
}
