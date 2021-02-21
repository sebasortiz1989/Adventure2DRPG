using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;
    private CharacterStats charStats;

    public string startText, completeText;

    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    public int enemiesKilled;

    [SerializeField] int questExperience;

    // Start is called before the first frame update
    void Start()
    {
        charStats = FindObjectOfType<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (needsItem && manager.itemCollected.Equals(itemNeeded))
        {
            manager.itemCollected = "NoItem";
            CompleteQuest();
        }

        if (needsEnemy && manager.enemyKilled.Equals(enemyName))
        {
            manager.enemyKilled = "NoEnemy";
            enemiesKilled++;
            if (enemiesKilled >= numberOfEnemies)
            {
                CompleteQuest();
            }
        }
    }

    public void StartQuest()
    {
        manager = GetComponentInParent<QuestManager>();
        manager.ShowQuestText(startText);
    }

    public void CompleteQuest()
    {
        manager.ShowQuestText(completeText);
        manager.questCompleted[questID] = true;
        charStats.AddExperience(questExperience);
        gameObject.SetActive(false);
    }
}
