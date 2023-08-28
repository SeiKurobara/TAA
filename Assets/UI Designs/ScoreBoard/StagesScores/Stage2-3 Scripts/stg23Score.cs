using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg23Score : MonoBehaviour
{
    //Score
    public int stg23CurrentScore;
    public int stg23CurrentScore2;
    public int stg23HighScore;
    public TextMeshProUGUI stg23seecurrentScore;
    public TextMeshProUGUI stg23seeCurrentScorePanel;

    //Timer

    bool stg23StopWatchActive = false;
    float stg23CurrentTime2;
    float stg23CurrentTime;
    float stg23HighScoreTime;
   
    
    public TextMeshProUGUI stg23CurrentTimeText;
    public TextMeshProUGUI stg23seeCurrentTimePanel;

    // Score
    public void Stg23ScorePointIncrease(int stg23PointIncrease)
    {
        stg23CurrentScore += stg23PointIncrease;
        Debug.Log("+Points Stg23");

    }

   

    public void Stg23ScorePointDecrease(int stg23PointDecrease)
    {
        stg23CurrentScore -= stg23PointDecrease;
        if (stg23CurrentScore < 0)
            stg23CurrentScore = 0;
    }

    public void Stg23SaveScoretoHighScore()
    {
        if (stg23CurrentScore >=stg23HighScore )
        {
             PlayerPrefs.SetInt("Stg23HighScore", stg23CurrentScore);
        }
        
    }

    //Timer
    public void Stg23StartTimer()
    {
        stg23StopWatchActive = true;
        Debug.Log("Timer Start");
    }

    public void Stg23StopTimer()
    {
        stg23StopWatchActive = false;
        Debug.Log("Timer Stop");
    }

    public void Stg23TimerHighScore()
    {
        if ( stg23CurrentTime < stg23HighScoreTime)
        {
            PlayerPrefs.SetFloat("Stg23TimerHighScore", stg23CurrentTime);
            Debug.Log("Timer High Score Recorded");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stg23CurrentTime = 0;
        Stg23StartTimer();


        stg23HighScoreTime = PlayerPrefs.GetFloat("Stg23TimerHighScore", 999);
    }

    // Update is called once per frame
    void Update()
    {
        //Score
        stg23seecurrentScore.text = "Score: " + stg23CurrentScore.ToString();

        stg23CurrentScore2 = stg23CurrentScore;
        stg23seeCurrentScorePanel.text = "Score: " + stg23CurrentScore2.ToString();


        //Timer
        if (stg23StopWatchActive == true)
        {
            stg23CurrentTime = stg23CurrentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(stg23CurrentTime);
        stg23CurrentTimeText.text = "Time: " + time.Minutes.ToString() + "mins " + time.Seconds.ToString() + "Secs";


        stg23CurrentTime2 = stg23CurrentTime;
        TimeSpan time2 = TimeSpan.FromSeconds(stg23CurrentTime2);
        stg23seeCurrentTimePanel.text = "Time: " + time2.Minutes.ToString() + "mins " + time2.Seconds.ToString() + "Secs";


        Debug.Log(stg23CurrentTime);
    }
}
