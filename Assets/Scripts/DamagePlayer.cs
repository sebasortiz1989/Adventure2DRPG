using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] GameObject damageNumber;

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
