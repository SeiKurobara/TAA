using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    public GameObject canScoreBoard;
    public GameObject charCon;
    public ScoreManager scoreMan;

    private void OnTriggerEnter(Collider other)
    {
        canScoreBoard.SetActive(true);
        charCon.SetActive(false);
        scoreMan.StopTimer();
        scoreMan.TimerHighScore();

    }
    // need to attach at Button
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
