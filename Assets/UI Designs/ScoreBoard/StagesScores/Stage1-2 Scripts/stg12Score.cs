using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg12Score : MonoBehaviour
{
    //Score
    public int stg12CurrentScore;
    public int stg12CurrentScore2;
    public int stg12HighScore;
    public TextMeshProUGUI stg12seecurrentScore;
    public TextMeshProUGUI stg12seeCurrentScorePanel;

    //Timer

    bool stg12StopWatchActive = false;
    float stg12CurrentTime2;
    float stg12CurrentTime;
    float stg12HighScoreTime;
   
    
    public TextMeshProUGUI stg12CurrentTimeText;
    public TextMeshProUGUI stg12seeCurrentTimePanel;

    // Score
    public void Stg12ScorePointIncrease(int stg12PointIncrease)
    {
        stg12CurrentScore += stg12PointIncrease;
        Debug.Log("+Points Stg12");

    }

   

    public void Stg12ScorePointDecrease(int stg12PointDecrease)
    {
        stg12CurrentScore -= stg12PointDecrease;
        if (stg12CurrentScore < 0)
            stg12CurrentScore = 0;
    }

    public void Stg12SaveScoretoHighScore()
    {
        if (stg12CurrentScore >=stg12HighScore )
        {
             PlayerPrefs.SetInt("Stg12HighScore", stg12CurrentScore);
        }
        
    }

    //Timer
    public void Stg12StartTimer()
    {
        stg12StopWatchActive = true;
        Debug.Log("Timer Start");
    }

    public void Stg12StopTimer()
    {
        stg12StopWatchActive = false;
        Debug.Log("Timer Stop");
    }

    public void Stg12TimerHighScore()
    {
        if ( stg12CurrentTime < stg12HighScoreTime)
        {
            PlayerPrefs.SetFloat("Stg12TimerHighScore", stg12CurrentTime);
            Debug.Log("Timer High Score Recorded");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stg12CurrentTime = 0;
        Stg12StartTimer();


        stg12HighScoreTime = PlayerPrefs.GetFloat("Stg12TimerHighScore", 999);
    }

    // Update is called once per frame
    void Update()
    {
        //Score
        stg12seecurrentScore.text = "Score: " + stg12CurrentScore.ToString();

        stg12CurrentScore2 = stg12CurrentScore;
        stg12seeCurrentScorePanel.text = "Score: " + stg12CurrentScore2.ToString();


        //Timer
        if (stg12StopWatchActive == true)
        {
            stg12CurrentTime = stg12CurrentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(stg12CurrentTime);
        stg12CurrentTimeText.text = "Time: " + time.Minutes.ToString() + "mins " + time.Seconds.ToString() + "Secs";


        stg12CurrentTime2 = stg12CurrentTime;
        TimeSpan time2 = TimeSpan.FromSeconds(stg12CurrentTime2);
        stg12seeCurrentTimePanel.text = "Time: " + time2.Minutes.ToString() + "mins " + time2.Seconds.ToString() + "Secs";


        Debug.Log(stg12CurrentTime);
    }
}
