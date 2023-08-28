using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public CursorState cursor;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
           
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        cursor.CursorOff();
    }

    void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        cursor.CursorOn();
    }

    public void pSettingMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Settings Menu");
        

    }

    public void quitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        gameIsPaused = false;
    }

  
}
