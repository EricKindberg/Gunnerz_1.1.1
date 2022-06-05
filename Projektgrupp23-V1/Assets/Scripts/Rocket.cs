using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float bulletLifeTime = 4f;
    [SerializeField] GameObject explosionPrefab;

    private void Start()
    {
        Collider2D colliderToIgnore = GameObject.FindGameObjectWithTag("CanShootThrough").GetComponent<CompositeCollider2D>();
        Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), colliderToIgnore);
        StartCoroutine(SelfDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "CanShootThrough")
        {
            Instantiate(explosionPrefab, GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
