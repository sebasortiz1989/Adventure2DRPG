using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;

    public Slider playerExpBar;
    public Text playerExpText;
    public HealthManager playerHealth;

    public Text playerLevel;

    // Start is called before the first frame update
    void Start()
    {
        playerExpBar.minValue = currentExp;
        playerExpBar.maxValue = expToLevelUp[currentLevel];
        playerExpText.text = "XP: " + currentExp + "/" + expToLevelUp[currentLevel];
        playerLevel.text = "Lvl: " + currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel >= expToLevelUp.Length)
        {
            return;
        }

        if (currentExp >= expToLevelUp[currentLevel])
        {
            currentLevel++;
            playerLevel.text = "Lvl: " + currentLevel;
            playerHealth.maxHealth += 20 * currentLevel;
            playerHealth.currentHealth = playerHealth.maxHealth;

            playerExpBar.minValue = currentExp;
            playerExpBar.maxValue = expToLevelUp[currentLevel];
            playerExpText.text = "XP: " + currentExp + "/" + expToLevelUp[currentLevel];
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
        playerExpBar.value = currentExp;

        playerExpText.text = "XP: " + currentExp + "/" + expToLevelUp[currentLevel];
    }
}
