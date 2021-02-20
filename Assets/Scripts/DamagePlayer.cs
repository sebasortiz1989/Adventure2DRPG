using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] GameObject damageNumber;

    private CharacterStats playerStats;
    private int playerLevel;

    private void Awake()
    {
        playerStats = FindObjectOfType<CharacterStats>();
        playerLevel = playerStats.currentLevel;
    }

    private void Update()
    {
        if (playerStats.currentLevel > playerLevel)
        {
            damage = damage - playerStats.defenseLevels[playerStats.currentLevel];
            playerLevel = playerStats.currentLevel;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            var clone = (GameObject)Instantiate(damageNumber, collision.transform.position + new Vector3(2,0,0), Quaternion.identity);
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }
    }
}
