using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public  int scoreCount;

    private void Start()
    {
        scoreCount = 0;
    }
    private void Update()
    {
        UpdateScore();
        
    }
    public void AddScore(int newScore)
    {
        scoreCount += newScore;
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + scoreCount;
    }
}
