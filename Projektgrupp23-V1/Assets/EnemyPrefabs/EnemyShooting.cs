using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public int damage; //efter instansiering i "FireContiunuously" sätts bullet damage till "damage"
    Transform target;
    public float shootingRadius;
    public float timeBetweenShots = 2.0f;
    bool inRange = false;
    private Rigidbody2D bulletRb;
    private GameObject bullet;
    private Rigidbody2D thisRb;
    Coroutine shootingCoroutine;

    public float fireRate = 15f;
    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        thisRb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMovement>().transform;
        Vector2 direction = (target.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        UpdatingDirection();
        Shoot();
    }
    private void LateUpdate()
    {

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
            // StopAllCoroutines() This would also work however we would be
            // unable to use any other coroutine inside the program.
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
        // This while loop is always true, the way we enter and exit it is to
        // start and end the coroutine method!
        while (Vector2.Distance(target.position, thisRb.transform.position) <= shootingRadius && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            InstantiateBullet();
            yield return new WaitForSeconds(timeBetweenShots);
            //InstantiateBullet();


            // This yield statement ensures that the projectiles are shot at a reasonable
            // pase. 
        }
    }

    void InstantiateBullet()
    {
        Vector2 dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y).normalized;
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<BulletEnemy>().damage = damage;
        bulletRb.velocity = new Vector2(dir.x * bulletForce,
            dir.y * bulletForce);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }
}
