using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg12ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI stg12HighScoreText;
    public TextMeshProUGUI stg12HighScoreTimerText;
    public int stg12ScoreBoardScore;
    public float stg12ScoreBoardTime;
    // Start is called before the first frame update

   void Awake()
    {
        stg12ScoreBoardScore = PlayerPrefs.GetInt("Stg12HighScore", 0);
       
    }
    void Start()

    {
        stg12ScoreBoardTime = PlayerPrefs.GetFloat("Stg12TimerHighScore", 0);
        stg12HighScoreText.text = stg12ScoreBoardScore.ToString();
        TimeSpan stg12TimeHigh = TimeSpan.FromSeconds(stg12ScoreBoardTime);
        stg12HighScoreTimerText.text =  stg12TimeHigh.Minutes.ToString() + "mins " + stg12TimeHigh.Seconds.ToString() + "secs";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
