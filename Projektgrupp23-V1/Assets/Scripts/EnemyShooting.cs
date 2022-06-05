using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 20f;
    [SerializeField] float damage;
    [SerializeField] float shootingRadius;
    [SerializeField] float timeBetweenShots = 2.0f;
    [SerializeField] float fireRate = 15f;
    private Transform target;
    private Rigidbody2D bulletRb;
    private GameObject bullet;

    private Rigidbody2D thisRb;
    private Coroutine shootingCoroutine;
    private bool inRange = false;
    private float nextFire = 0f;

    void Start()
    {
        thisRb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMovement>().transform;
        Vector2 direction = (target.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        UpdatingDirection();
        Shoot();
    }
    void Shoot()
    {
        if (Vector2.Distance(target.position, thisRb.transform.position) <= shootingRadius)
        {
            FireContinuously();
            shootingCoroutine = StartCoroutine(FireContinuously());
            inRange = true;
        }
        else if (Vector2.Distance(target.position, thisRb.transform.position) <= shootingRadius && inRange == true)
        {
            StopCoroutine(shootingCoroutine);
            inRange = false;
        }
    }
    void UpdatingDirection()
    {
        var ePos = thisRb.transform.position;
        var tPos = target.position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(tPos.y - ePos.y, tPos.x - ePos.x) - 90f;
        thisRb.rotation = angle;
    }

    IEnumerator FireContinuously()
    {
        while (Vector2.Distance(target.position, thisRb.transform.position) <= shootingRadius && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            InstantiateBullet();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    void InstantiateBullet()
    {
        Vector2 dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletEnemy>().Damage = damage;
        bulletRb.velocity = new Vector2(dir.x * bulletForce,
            dir.y * bulletForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }
}
