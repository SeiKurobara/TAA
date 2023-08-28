using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class stg23RecordSaveNNextLevel : MonoBehaviour
{
    public stg23Score Scores;
    public TextMeshProUGUI panelHighScoretxt;
    public TextMeshProUGUI panelHighTimetxt;
    public int panelHighScore;
    public float panelHighScoreTime;
    public GameObject Scorepanel;
    public GameObject Player;
    public CursorState cursor;

    private void OnTriggerEnter(Collider other)
    {
        Scores.Stg23TimerHighScore();
        Scores.Stg23StopTimer();
        
        Scores.Stg23SaveScoretoHighScore();    
        Debug.Log("ScoreSaved");
        Scorepanel.SetActive(true);

        panelHighScoretxt.text = "Score:" + PlayerPrefs.GetInt("Stg23HighScore",0).ToString();

        panelHighScoreTime = PlayerPrefs.GetFloat ("Stg23TimerHighScore", 0);

        TimeSpan  stg23ScoreBoardTimeHighPanel = TimeSpan.FromSeconds(panelHighScoreTime);
        panelHighTimetxt.text = "Time: " + stg23ScoreBoardTimeHighPanel.Minutes.ToString() + "mins" + stg23ScoreBoardTimeHighPanel.Seconds.ToString() + "secs";
        Player.gameObject.SetActive(false);
        cursor.CursorOn();
    }
void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
