using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] GameObject hurtAnimation;
    [SerializeField] GameObject hitPoint;

    private GameObject blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            blood = Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(blood, 1.5f);
        }
    }
}
