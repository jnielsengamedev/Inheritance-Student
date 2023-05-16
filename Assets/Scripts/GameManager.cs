using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI healthDisplay;

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreDisplay.text = "Score: " + score;
    }

}
