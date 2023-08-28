using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject instructionPanel;
    public CharacterController charCon;

     void Start()
    {
        OpenPanel();
    }
    public void ClosePanel()
    {
        instructionPanel.SetActive(false);
        charCon.enabled = true;
    }
    public void OpenPanel()
    {
        instructionPanel.SetActive(true);
        charCon.enabled = false;
    }
}
