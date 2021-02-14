﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;

    public HealthManager playerHealthManager;

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        playerHealthText.text = "HP: " + playerHealthBar.maxValue + "/" + playerHealthBar.value;
    }
}
