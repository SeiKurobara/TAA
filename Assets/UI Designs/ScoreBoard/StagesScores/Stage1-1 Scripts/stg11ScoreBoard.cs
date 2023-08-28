using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg11ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI stg11HighScoreText;
    public TextMeshProUGUI stg11HighScoreTimerText;
    public int stg11ScoreBoardScore;
    public float stg11ScoreBoardTime;
    // Start is called before the first frame update

   void Awake()
    {
        stg11ScoreBoardScore = PlayerPrefs.GetInt("Stg11HighScore", 0);
       
    }
    void Start()

    {
        stg11ScoreBoardTime = PlayerPrefs.GetFloat("Stg11TimerHighScore", 0);
        stg11HighScoreText.text = stg11ScoreBoardScore.ToString();
        TimeSpan stg11TimeHigh = TimeSpan.FromSeconds(stg11ScoreBoardTime);
        stg11HighScoreTimerText.text =  stg11TimeHigh.Minutes.ToString() + "mins " + stg11TimeHigh.Seconds.ToString() + "secs";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
