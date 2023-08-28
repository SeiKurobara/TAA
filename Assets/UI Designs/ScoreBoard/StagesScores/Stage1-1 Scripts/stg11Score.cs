using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg11Score : MonoBehaviour
{
    //Score
    public int stg11CurrentScore;
    public int stg11CurrentScore2;
    public int stg11HighScore;
    public TextMeshProUGUI stg11seecurrentScore;
    public TextMeshProUGUI stg11seeCurrentScorePanel;

    //Timer

    bool stg11StopWatchActive = false;
    float stg11CurrentTime2;
    float stg11CurrentTime;
    float stg11HighScoreTime;
    float sample = 10f;
    
    public TextMeshProUGUI stg11CurrentTimeText;
    public TextMeshProUGUI stg11seeCurrentTimePanel;

    // Score
    public void Stg11ScorePointIncrease(int stg11PointIncrease)
    {
        stg11CurrentScore += stg11PointIncrease;
        Debug.Log("+Points Stg11");

    }

   

    public void Stg11ScorePointDecrease(int stg11PointDecrease)
    {
        stg11CurrentScore -= stg11PointDecrease;
        if (stg11CurrentScore < 0)
            stg11CurrentScore = 0;
    }

    public void Stg11SaveScoretoHighScore()
    {
        if (stg11CurrentScore >=stg11HighScore )
        {
             PlayerPrefs.SetInt("Stg11HighScore", stg11CurrentScore);
        }
        
    }

    //Timer
    public void Stg11StartTimer()
    {
        stg11StopWatchActive = true;
        Debug.Log("Timer Start");
    }

    public void Stg11StopTimer()
    {
        stg11StopWatchActive = false;
        Debug.Log("Timer Stop");
    }

    public void Stg11TimerHighScore()
    {
        if ( stg11CurrentTime < stg11HighScoreTime)
        {
            PlayerPrefs.SetFloat("Stg11TimerHighScore", stg11CurrentTime);
            Debug.Log("Timer High Score Recorded");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stg11CurrentTime = 0;
        Stg11StartTimer();


        stg11HighScoreTime = PlayerPrefs.GetFloat("Stg11TimerHighScore", 999);
    }

    // Update is called once per frame
    void Update()
    {
        //Score
        stg11seecurrentScore.text = "Score: " + stg11CurrentScore.ToString();

        stg11CurrentScore2 = stg11CurrentScore;
        stg11seeCurrentScorePanel.text = "Score: " + stg11CurrentScore2.ToString();


        //Timer
        if (stg11StopWatchActive == true)
        {
            stg11CurrentTime = stg11CurrentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(stg11CurrentTime);
        stg11CurrentTimeText.text = "Time: " + time.Minutes.ToString() + "mins " + time.Seconds.ToString() + "Secs";


        stg11CurrentTime2 = stg11CurrentTime;
        TimeSpan time2 = TimeSpan.FromSeconds(stg11CurrentTime2);
        stg11seeCurrentTimePanel.text = "Time: " + time2.Minutes.ToString() + "mins " + time2.Seconds.ToString() + "Secs";


        Debug.Log(stg11CurrentTime);
    }
}
