using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }
    public void GameOver(float score)
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        scoreText.text = "SCORE: " + ((int)score).ToString();
    }
}
