using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 1;
    BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
    private void OnParticleCollision(GameObject other) //en av dessa ska användas en kan tas bortt
    {
        if (other.tag == "Player" || other.tag == "player")
        {
            ;
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
