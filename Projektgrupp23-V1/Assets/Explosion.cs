using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float explosionLifeTime = .2f;
    public float explosionArea = 5;
    public int areaDamage = 2;

    private void Start()
    {
        StartCoroutine(SelfDestroy());
        GetComponent<Transform>().localScale = new Vector3(explosionArea, explosionArea, explosionArea);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakingDamage(areaDamage);
        }
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(explosionLifeTime);
        Destroy(gameObject);
    }
}
