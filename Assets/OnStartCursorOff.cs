using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStartCursorOff : MonoBehaviour
{
    public CursorState cursorState;
    [HideInInspector]public string sceneName;
    public string MainMenu = "MainMenu";


    void Awake()
    {
        MainMenuCursorOn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuCursorOn()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (!sceneName.Equals(MainMenu))
        {
            cursorState.CursorOff();
        }
        else
        {
            cursorState.CursorOn();
        }
    }
}
