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
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovements>();
        maxBlood = player.blood;
    }

    void Update()
    {
        currentBlood = player.blood;
        healthBar.fillAmount = currentBlood / maxBlood;
    }
}
