﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private void Update()
    {
        score = Score.getScore();
        scoreText.text = "Score: " + score;
    }
}
