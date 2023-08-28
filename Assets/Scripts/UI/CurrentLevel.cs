using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrentLevel : MonoBehaviour
{
    public TextMeshProUGUI currentLevel;
    private string currentLevelString;
    // Start is called before the first frame update
    void Start()
    {
        currentLevelString = SceneManager.GetActiveScene().name;

        currentLevel.text = currentLevelString.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
