using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float bulletLifeTime = 4f;
    public GameObject explosionPrefab;

    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        Instantiate(explosionPrefab, GetComponent<Transform>().position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
