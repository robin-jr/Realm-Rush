using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] int score = 0;

    [SerializeField] ScoreText scoreText;
    [SerializeField] HealthText healthText;
    void Start()
    {
        scoreText.SetScoreText(score.ToString());
        healthText.SetHealthText(health.ToString());
    }

    public void DecreaseHealth()
    {
        health--;
        healthText.SetHealthText(health.ToString());
    }

    public void IncreaseScore()
    {
        score += 50;
        scoreText.SetScoreText(score.ToString());
    }
}
