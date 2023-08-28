using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg22ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI stg22HighScoreText;
    public TextMeshProUGUI stg22HighScoreTimerText;
    public int stg22ScoreBoardScore;
    public float stg22ScoreBoardTime;
    // Start is called before the first frame update

   void Awake()
    {
        stg22ScoreBoardScore = PlayerPrefs.GetInt("Stg22HighScore", 0);
       
    }
    void Start()

    {
        stg22ScoreBoardTime = PlayerPrefs.GetFloat("Stg22TimerHighScore", 0);
        stg22HighScoreText.text = stg22ScoreBoardScore.ToString();
        TimeSpan stg22TimeHigh = TimeSpan.FromSeconds(stg22ScoreBoardTime);
        stg22HighScoreTimerText.text =  stg22TimeHigh.Minutes.ToString() + "mins " + stg22TimeHigh.Seconds.ToString() + "secs";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
