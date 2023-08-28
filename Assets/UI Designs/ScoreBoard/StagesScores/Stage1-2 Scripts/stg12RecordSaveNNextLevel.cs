using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class stg12RecordSaveNNextLevel : MonoBehaviour
{
    public stg12Score Scores;
    public TextMeshProUGUI panelHighScoretxt;
    public TextMeshProUGUI panelHighTimetxt;
    public int panelHighScore;
    public float panelHighScoreTime;
    public GameObject Scorepanel;
    public GameObject Player;
    public CursorState cursor;

    private void OnTriggerEnter(Collider other)
    {
        Scores.Stg12TimerHighScore();
        Scores.Stg12StopTimer();
        
        Scores.Stg12SaveScoretoHighScore();    
        Debug.Log("ScoreSaved");
        Scorepanel.SetActive(true);

        panelHighScoretxt.text = "Score:" + PlayerPrefs.GetInt("Stg12HighScore",0).ToString();

        panelHighScoreTime = PlayerPrefs.GetFloat ("Stg12TimerHighScore", 0);

        TimeSpan  stg12ScoreBoardTimeHighPanel = TimeSpan.FromSeconds(panelHighScoreTime);
        panelHighTimetxt.text = "Time: " + stg12ScoreBoardTimeHighPanel.Minutes.ToString() + "mins" + stg12ScoreBoardTimeHighPanel.Seconds.ToString() + "secs";
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
