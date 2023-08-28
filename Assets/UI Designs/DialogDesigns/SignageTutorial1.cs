using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignageTutorial1 : MonoBehaviour
{
    public GameObject SignagePanel;


     void Start()
    {
    }
    public void ClosePanel()
    {
        SignagePanel.SetActive(false);
    }
    public void OpenPanel()
    {
        SignagePanel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        OpenPanel();
    }

    private void OnTriggerExit(Collider other)
    {
        ClosePanel();
    }
}
