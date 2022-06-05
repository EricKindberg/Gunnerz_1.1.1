using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLifeTime = 4f;
    [SerializeField] int bulletDamage = 10;
    [SerializeField] GameObject hitEffect;
    private void Start()
    {
        var colliderToIgnore = GameObject.FindGameObjectWithTag("Water").GetComponent<CompositeCollider2D>();
        Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(),colliderToIgnore);
        StartCoroutine(SelfDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(bulletDamage);
        }
        if (collision.gameObject.tag == "Destructible")
        {
            collision.gameObject.GetComponent<DestructibleHealth>().TakingDamage(bulletDamage);
        }
        if (collision.gameObject.tag != "Water")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.25f);
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
