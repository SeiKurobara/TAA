using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignageTutorial : MonoBehaviour
{
    public GameObject SignagePanel;
    public CharacterController charCon;

     void Start()
    {
    }
    public void ClosePanel()
    {
        SignagePanel.SetActive(false);
        charCon.enabled = true;
    }
    public void OpenPanel()
    {
        SignagePanel.SetActive(true);
        charCon.enabled = false;
    }
}
