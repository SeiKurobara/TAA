using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOnStart : MonoBehaviour
{

    void Awake()
    {
        OnStartSaveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
   

    public void OnStartSaveScene()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved1", activeScene);

        Debug.Log(activeScene);
    }
        
}
