using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class stg22RecordSaveNNextLevel : MonoBehaviour
{
    public stg22Score Scores;
    public TextMeshProUGUI panelHighScoretxt;
    public TextMeshProUGUI panelHighTimetxt;
    public int panelHighScore;
    public float panelHighScoreTime;
    public GameObject Scorepanel;
    public GameObject Player;
    public CursorState cursor;
    private void OnTriggerEnter(Collider other)
    {
        Scores.Stg22TimerHighScore();
        Scores.Stg22StopTimer();
        
        Scores.Stg22SaveScoretoHighScore();    
        Debug.Log("ScoreSaved");
        Scorepanel.SetActive(true);

        panelHighScoretxt.text = "Score:" + PlayerPrefs.GetInt("Stg22HighScore",0).ToString();

        panelHighScoreTime = PlayerPrefs.GetFloat ("Stg22TimerHighScore", 0);

        TimeSpan  stg22ScoreBoardTimeHighPanel = TimeSpan.FromSeconds(panelHighScoreTime);
        panelHighTimetxt.text = "Time: " + stg22ScoreBoardTimeHighPanel.Minutes.ToString() + "mins" + stg22ScoreBoardTimeHighPanel.Seconds.ToString() + "secs";
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
