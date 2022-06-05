using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    GameObject bullet;
    Rigidbody2D rb;
    public Camera cam;
    public float bulletForce = 20f;
    Vector2 mousePos;

    public float damage = 1f;
    public float fireRate = 15f;
    public int maxAmmo = 10;
    private int currentAmmo;

    public float reloadTime = 1f;
    private float nextTimeToFire =0f;
    private bool isReloading = false;

    // Update is called once per frame
    private void Start()
    {
        currentAmmo = maxAmmo;

    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (isReloading)
        {
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void FixedUpdate()
    {

    }

    void Shoot()
    {
        currentAmmo--;

        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        rb.velocity = new Vector2(bulletForce * dir.x, bulletForce * dir.y);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
