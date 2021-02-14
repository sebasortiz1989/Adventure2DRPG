using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] int damage = 11;
    [SerializeField] GameObject hurtAnimation;
    [SerializeField] GameObject hitPoint;
    [SerializeField] GameObject damageNumber;

    private GameObject blood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            blood = Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);

            var clone = (GameObject) Instantiate(damageNumber, hitPoint.transform.position + new Vector3(2,0,0), Quaternion.identity);
            clone.GetComponent<DamageNumber>().damagePoints = damage;
            
            Destroy(blood, 1.5f);
        }
    }
}
