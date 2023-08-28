using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    public int currentScore;
    public int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI seeScoreText;
    public TextMeshProUGUI seeTimeText;

    //Timer
    bool stopWatchActive = false;
    float currentTime;
    float highScoreTime;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI highScoreTimeText;

    //Increase the points
    public void ScorePointsInc(int scorePointsInc)
    {
        currentScore += scorePointsInc;
        Debug.Log("+Points");
        //Saves the highscore to PlayerPref
        if (highScore < currentScore)
            PlayerPrefs.SetInt("highscore", currentScore);
    }

    //Decrease the points
    public void ScorePointsDec(int scorePointsDec)
    {
        Debug.Log("-Points");
        currentScore -= scorePointsDec;
        // the current score cant be decrease by 0
        if (currentScore < 0)
        {
            currentScore = 0;
        }

    }
    //Resets the Highscore
    public void ResetScore()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteKey("highscore");
        }
    }
    //-----Timer
    public void StartTimer()
    {
        stopWatchActive = true;
    }

    public void StopTimer()
    {
        stopWatchActive = false;
    }

    public void TimerHighScore()
    {
        if (highScoreTime > currentTime)
        {
            PlayerPrefs.SetFloat("timerHighScore",currentTime);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentScore);
        //Load the highscore from PlayerPref
        highScore = PlayerPrefs.GetInt("highscore", 0);

        //Display the Score text w/ value
        scoreText.text = "Score: " + currentScore.ToString();
        seeScoreText.text = "Score: " + currentScore.ToString();

        //Display the HighScore text w/ value
        highScoreText.text = "HighScore: " + highScore.ToString();

        //Function that resets the Highscore
       // ResetScore();

        //-----Timer

        if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text ="Time: " + time.Minutes.ToString() +"mins"+ ":" + time.Seconds.ToString()+"secs";
        Debug.Log(currentTime);

        highScoreTime = PlayerPrefs.GetFloat("timerHighScore", 0);
        seeTimeText.text = "Time: " + time.Minutes.ToString() + "mins:"+ time.Seconds.ToString() + "secs";


        TimeSpan timeHigh = TimeSpan.FromSeconds(highScoreTime);
        highScoreTimeText.text = "Time: " + timeHigh.Minutes.ToString()+"mins" + ":" + timeHigh.Seconds.ToString()+"secs";
    }



}
