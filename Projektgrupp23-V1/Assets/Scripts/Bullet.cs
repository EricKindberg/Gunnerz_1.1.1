using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifeTime = 4f;
    public int bulletDamage = 10;
    public GameObject hitEffect;
    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(bulletDamage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(bulletDamage);
            //enemy.HandleDamage(bulletDamage);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
