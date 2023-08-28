using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameMenu : MonoBehaviour
{
  public void LoadGameButton()
    {
        if (PlayerPrefs.HasKey("LevelSaved1"))
        {
            string levelToLoad = PlayerPrefs.GetString("LevelSaved1");
            SceneManager.LoadScene(levelToLoad);
            Debug.Log("Level Loaded "+levelToLoad);
        }
    }
}
