using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text finalScore;

    private void Update()
    {
        score = Score.getScore();
        scoreText.text = "Score: " + score;
        finalScore.text = "Score: " + score;
    }
}
