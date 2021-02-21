using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour
{
    public int questID;
    private QuestManager manager;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (manager.quests[questID].gameObject.activeInHierarchy && !manager.questCompleted[questID])
            {
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
