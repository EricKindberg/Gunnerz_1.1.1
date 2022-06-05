using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float explosionLifeTime = .2f;
    [SerializeField] float explosionArea = 5;
    [SerializeField] int areaDamage = 2;

    private void Start()
    {
        StartCoroutine(SelfDestroy());
        GetComponent<Transform>().localScale = new Vector3(explosionArea, explosionArea, explosionArea);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(areaDamage);
        }
        if (collision.gameObject.tag == "Destructible")
        {
            collision.gameObject.GetComponent<DestructibleHealth>().TakingDamage(areaDamage);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(explosionLifeTime);
        Destroy(gameObject);
    }
}
