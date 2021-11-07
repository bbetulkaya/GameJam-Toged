using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Score score;
    public HealthBar healthBar;
    public GameOverScreen gameOver;
    public PlayerMovements player;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>();
        healthBar = GetComponent<HealthBar>();
        gameOver = GetComponent<GameOverScreen>();

    }

    public void GameOver()
    {
        gameOver.GameOver(score.score);
    }
}
