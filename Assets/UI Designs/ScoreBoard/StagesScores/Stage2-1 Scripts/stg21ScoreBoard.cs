using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg21ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI stg21HighScoreText;
    public TextMeshProUGUI stg21HighScoreTimerText;
    public int stg21ScoreBoardScore;
    public float stg21ScoreBoardTime;
    // Start is called before the first frame update

   void Awake()
    {
        stg21ScoreBoardScore = PlayerPrefs.GetInt("Stg21HighScore", 0);
       
    }
    void Start()

    {
        stg21ScoreBoardTime = PlayerPrefs.GetFloat("Stg21TimerHighScore", 0);
        stg21HighScoreText.text = stg21ScoreBoardScore.ToString();
        TimeSpan stg21TimeHigh = TimeSpan.FromSeconds(stg21ScoreBoardTime);
        stg21HighScoreTimerText.text =  stg21TimeHigh.Minutes.ToString() + "mins " + stg21TimeHigh.Seconds.ToString() + "secs";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
