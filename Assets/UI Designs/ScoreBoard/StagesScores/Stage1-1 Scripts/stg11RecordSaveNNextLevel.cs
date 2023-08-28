using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class stg11RecordSaveNNextLevel : MonoBehaviour
{
    public stg11Score Scores;
    public TextMeshProUGUI panelHighScoretxt;
    public TextMeshProUGUI panelHighTimetxt;
    public int panelHighScore;
    public float panelHighScoreTime;
    public GameObject Scorepanel;
    public GameObject Player;
    public CursorState cursor;
  
    private void OnTriggerEnter(Collider other)
    {
        Scores.Stg11TimerHighScore();
        Scores.Stg11StopTimer();
        
        Scores.Stg11SaveScoretoHighScore();    
        Debug.Log("ScoreSaved");
        Scorepanel.SetActive(true);

        panelHighScoretxt.text = "Score:" + PlayerPrefs.GetInt("Stg11HighScore",0).ToString();

        panelHighScoreTime = PlayerPrefs.GetFloat ("Stg11TimerHighScore", 0);

        TimeSpan  stg11ScoreBoardTimeHighPanel = TimeSpan.FromSeconds(panelHighScoreTime);
        panelHighTimetxt.text = "Time: " + stg11ScoreBoardTimeHighPanel.Minutes.ToString() + "mins" + stg11ScoreBoardTimeHighPanel.Seconds.ToString() + "secs";
        Player.gameObject.SetActive(false);
        cursor.CursorOn();
        
    }
void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        cursor.CursorOff();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
