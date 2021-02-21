﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;
    private CharacterStats charStats;

    public string startText, completeText;

    [SerializeField] int questExperience;

    // Start is called before the first frame update
    void Start()
    {
        charStats = FindObjectOfType<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
