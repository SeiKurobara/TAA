using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg22Score : MonoBehaviour
{
    //Score
    public int stg22CurrentScore;
    public int stg22CurrentScore2;
    public int stg22HighScore;
    public TextMeshProUGUI stg22seecurrentScore;
    public TextMeshProUGUI stg22seeCurrentScorePanel;

    //Timer

    bool stg22StopWatchActive = false;
    float stg22CurrentTime2;
    float stg22CurrentTime;
    float stg22HighScoreTime;
   
    
    public TextMeshProUGUI stg22CurrentTimeText;
    public TextMeshProUGUI stg22seeCurrentTimePanel;

    // Score
    public void Stg22ScorePointIncrease(int stg22PointIncrease)
    {
        stg22CurrentScore += stg22PointIncrease;
        Debug.Log("+Points Stg22");

    }

   

    public void Stg22ScorePointDecrease(int stg22PointDecrease)
    {
        stg22CurrentScore -= stg22PointDecrease;
        if (stg22CurrentScore < 0)
            stg22CurrentScore = 0;
    }

    public void Stg22SaveScoretoHighScore()
    {
        if (stg22CurrentScore >=stg22HighScore )
        {
             PlayerPrefs.SetInt("Stg22HighScore", stg22CurrentScore);
        }
        
    }

    //Timer
    public void Stg22StartTimer()
    {
        stg22StopWatchActive = true;
        Debug.Log("Timer Start");
    }

    public void Stg22StopTimer()
    {
        stg22StopWatchActive = false;
        Debug.Log("Timer Stop");
    }

    public void Stg22TimerHighScore()
    {
        if ( stg22CurrentTime < stg22HighScoreTime)
        {
            PlayerPrefs.SetFloat("Stg22TimerHighScore", stg22CurrentTime);
            Debug.Log("Timer High Score Recorded");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stg22CurrentTime = 0;
        Stg22StartTimer();


        stg22HighScoreTime = PlayerPrefs.GetFloat("Stg22TimerHighScore", 999);
    }

    // Update is called once per frame
    void Update()
    {
        //Score
        stg22seecurrentScore.text = "Score: " + stg22CurrentScore.ToString();

        stg22CurrentScore2 = stg22CurrentScore;
        stg22seeCurrentScorePanel.text = "Score: " + stg22CurrentScore2.ToString();


        //Timer
        if (stg22StopWatchActive == true)
        {
            stg22CurrentTime = stg22CurrentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(stg22CurrentTime);
        stg22CurrentTimeText.text = "Time: " + time.Minutes.ToString() + "mins " + time.Seconds.ToString() + "Secs";


        stg22CurrentTime2 = stg22CurrentTime;
        TimeSpan time2 = TimeSpan.FromSeconds(stg22CurrentTime2);
        stg22seeCurrentTimePanel.text = "Time: " + time2.Minutes.ToString() + "mins " + time2.Seconds.ToString() + "Secs";


        Debug.Log(stg22CurrentTime);
    }
}
