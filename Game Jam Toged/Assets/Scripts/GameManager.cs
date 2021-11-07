using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public UIController uIController;
    void Awake()
    {
        _instance = this;
    }
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }
    }

    // Add your game mananger members here
    public void Pause(bool paused)
    {
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        uIController.GameOver();
    }
}
