using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float bulletLifeTime = 4f;
    [SerializeField] int bulletDamage = 10;
    [SerializeField] int bulletHealth = 30;

    private void Start()
    {
        var colliderToIgnore = GameObject.FindGameObjectWithTag("Water").GetComponent<CompositeCollider2D>();
        Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), colliderToIgnore);
        StartCoroutine(SelfDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(bulletDamage);
            //bulletHealth -= bulletDamage;
            //if (bulletHealth <= 0)
            //{
            //  Destroy(gameObject);
            //}

        }

        if (collision.gameObject.tag == "Destructible")
        {
            collision.gameObject.GetComponent<DestructibleHealth>().TakingDamage(bulletDamage);
        }
        if (collision.gameObject.tag != "Water")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
