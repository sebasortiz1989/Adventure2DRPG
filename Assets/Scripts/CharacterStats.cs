using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;
    public int[] hpLevels, strengthLevel, defenseLevels;

    public Slider playerExpBar;
    public Text playerExpText;

    public Text playerLevel;

    private HealthManager healthManager;
    private WeaponDamage weaponDamage;
    private DamagePlayer[] enemyDamages;

    private void Awake()
    {
        healthManager = GetComponent<HealthManager>();
        weaponDamage = GetComponentInChildren<WeaponDamage>();
    }

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

            playerExpBar.minValue = currentExp;
            playerExpBar.maxValue = expToLevelUp[currentLevel];
            playerExpText.text = "XP: " + currentExp + "/" + expToLevelUp[currentLevel];

            //Stats update
            healthManager.UpDateMaxHealth(hpLevels[currentLevel]);
            weaponDamage.damage += strengthLevel[currentLevel];
        }
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
        playerExpBar.value = currentExp;

        playerExpText.text = "XP: " + currentExp + "/" + expToLevelUp[currentLevel];
    }
}
