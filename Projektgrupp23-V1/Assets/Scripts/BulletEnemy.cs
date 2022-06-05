using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    public float Damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
