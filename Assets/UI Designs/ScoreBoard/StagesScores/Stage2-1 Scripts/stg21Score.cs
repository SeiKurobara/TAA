using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg21Score : MonoBehaviour
{
    //Score
    public int stg21CurrentScore;
    public int stg21CurrentScore2;
    public int stg21HighScore;
    public TextMeshProUGUI stg21seecurrentScore;
    public TextMeshProUGUI stg21seeCurrentScorePanel;

    //Timer

    bool stg21StopWatchActive = false;
    float stg21CurrentTime2;
    float stg21CurrentTime;
    float stg21HighScoreTime;
   
    
    public TextMeshProUGUI stg21CurrentTimeText;
    public TextMeshProUGUI stg21seeCurrentTimePanel;

    // Score
    public void Stg21ScorePointIncrease(int stg21PointIncrease)
    {
        stg21CurrentScore += stg21PointIncrease;
        Debug.Log("+Points Stg21");

    }

   

    public void Stg21ScorePointDecrease(int stg21PointDecrease)
    {
        stg21CurrentScore -= stg21PointDecrease;
        if (stg21CurrentScore < 0)
            stg21CurrentScore = 0;
    }

    public void Stg21SaveScoretoHighScore()
    {
        if (stg21CurrentScore >=stg21HighScore )
        {
             PlayerPrefs.SetInt("Stg21HighScore", stg21CurrentScore);
        }
        
    }

    //Timer
    public void Stg21StartTimer()
    {
        stg21StopWatchActive = true;
        Debug.Log("Timer Start");
    }

    public void Stg21StopTimer()
    {
        stg21StopWatchActive = false;
        Debug.Log("Timer Stop");
    }

    public void Stg21TimerHighScore()
    {
        if ( stg21CurrentTime < stg21HighScoreTime)
        {
            PlayerPrefs.SetFloat("Stg21TimerHighScore", stg21CurrentTime);
            Debug.Log("Timer High Score Recorded");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stg21CurrentTime = 0;
        Stg21StartTimer();


        stg21HighScoreTime = PlayerPrefs.GetFloat("Stg21TimerHighScore", 999);
    }

    // Update is called once per frame
    void Update()
    {
        //Score
        stg21seecurrentScore.text = "Score: " + stg21CurrentScore.ToString();

        stg21CurrentScore2 = stg21CurrentScore;
        stg21seeCurrentScorePanel.text = "Score: " + stg21CurrentScore2.ToString();


        //Timer
        if (stg21StopWatchActive == true)
        {
            stg21CurrentTime = stg21CurrentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(stg21CurrentTime);
        stg21CurrentTimeText.text = "Time: " + time.Minutes.ToString() + "mins " + time.Seconds.ToString() + "Secs";


        stg21CurrentTime2 = stg21CurrentTime;
        TimeSpan time2 = TimeSpan.FromSeconds(stg21CurrentTime2);
        stg21seeCurrentTimePanel.text = "Time: " + time2.Minutes.ToString() + "mins " + time2.Seconds.ToString() + "Secs";


        Debug.Log(stg21CurrentTime);
    }
}
