using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class stg21RecordSaveNNextLevel : MonoBehaviour
{
    public stg21Score Scores;
    public TextMeshProUGUI panelHighScoretxt;
    public TextMeshProUGUI panelHighTimetxt;
    public int panelHighScore;
    public float panelHighScoreTime;
    public GameObject Scorepanel;
    public GameObject Player;
    public CursorState cursor;
    private void OnTriggerEnter(Collider other)
    {
        Scores.Stg21TimerHighScore();
        Scores.Stg21StopTimer();
        
        Scores.Stg21SaveScoretoHighScore();    
        Debug.Log("ScoreSaved");
        Scorepanel.SetActive(true);

        panelHighScoretxt.text = "Score:" + PlayerPrefs.GetInt("Stg21HighScore",0).ToString();

        panelHighScoreTime = PlayerPrefs.GetFloat ("Stg21TimerHighScore", 0);

        TimeSpan  stg21ScoreBoardTimeHighPanel = TimeSpan.FromSeconds(panelHighScoreTime);
        panelHighTimetxt.text = "Time: " + stg21ScoreBoardTimeHighPanel.Minutes.ToString() + "mins" + stg21ScoreBoardTimeHighPanel.Seconds.ToString() + "secs";
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
