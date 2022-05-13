using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float bulletLifeTime = 4f;
    public int bulletDamage = 10;
    public int bulletHealth = 30;

    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(bulletDamage);
            bulletHealth -= bulletDamage;
            if(bulletHealth <= 0)
            {
            }
            //enemy.HandleDamage(bulletDamage);
        }
                Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(bulletDamage);
            bulletHealth -= bulletDamage;
            if (bulletHealth <= 0)
            {
                Destroy(gameObject);
            }
            //enemy.HandleDamage(bulletDamage);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
