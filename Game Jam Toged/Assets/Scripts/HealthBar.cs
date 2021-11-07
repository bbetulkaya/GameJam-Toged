using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float maxBlood;
    public float currentBlood;
    PlayerMovements player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovements>();
        maxBlood = player.maxBlood;
    }

    void Update()
    {
        currentBlood = player.currentBlood;
        healthBar.fillAmount = currentBlood / maxBlood;
    }
}
