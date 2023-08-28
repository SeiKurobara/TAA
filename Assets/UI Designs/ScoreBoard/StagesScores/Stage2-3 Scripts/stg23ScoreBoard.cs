using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class stg23ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI stg23HighScoreText;
    public TextMeshProUGUI stg23HighScoreTimerText;
    public int stg23ScoreBoardScore;
    public float stg23ScoreBoardTime;
    // Start is called before the first frame update

   void Awake()
    {
        stg23ScoreBoardScore = PlayerPrefs.GetInt("Stg23HighScore", 0);
       
    }
    void Start()

    {
        stg23ScoreBoardTime = PlayerPrefs.GetFloat("Stg23TimerHighScore", 0);
        stg23HighScoreText.text = stg23ScoreBoardScore.ToString();
        TimeSpan stg23TimeHigh = TimeSpan.FromSeconds(stg23ScoreBoardTime);
        stg23HighScoreTimerText.text =  stg23TimeHigh.Minutes.ToString() + "mins " + stg23TimeHigh.Seconds.ToString() + "secs";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
