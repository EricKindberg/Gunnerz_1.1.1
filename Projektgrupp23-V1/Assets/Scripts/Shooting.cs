using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject projectilePrefab;
    public Camera cam;

    public GameObject muzzleFlashePrefab;
    public Transform muzzelFlashPos;

    public bool raycast = true;

    public float bulletForce = 20f;
    public int raycastDamage = 10;
    [Range(0f, 2f)] public float bulletTrailTime = 0.02f;

    public LineRenderer lineRenderer;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        //muzzleFlash();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            muzzleFlash();
            if(raycast)
            {
                StartCoroutine(Shoot_Raycast());
            } else
            {
                Shoot_Projectile();
            }
        }
    }

    void Shoot_Projectile()
    {

        Quaternion fireRotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);
        // Because the Bullet asset is laying sideways I had to rotate the bullet 90%

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, fireRotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void muzzleFlash()
    {
        Quaternion fireRotation = firePoint.rotation * Quaternion.Euler(-180, 90, -90);
        //Vector3 muzzelFlashPos = firePoint.position;
        //GameObject flash = Instantiate(muzzleFlashePrefab, muzzelFlashPos, fireRotation, firePoint);
        //flash.transform.position += new Vector3(0.612f, 0.268f, 0f);
        GameObject flash = Instantiate(muzzleFlashePrefab, muzzelFlashPos.position, fireRotation, firePoint.transform);
    }

    IEnumerator Shoot_Raycast()
    {
        //Vector3 mouseMag = ;
        float distance = Vector3.Distance(firePoint.position, Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
        if(hitInfo)
        {
            Enemy enemy = hitInfo.transform.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.HandleDamage(raycastDamage);
            }

            /*
            Debug.Log("Firepoint Pos: " + firePoint.position);
            Debug.Log("MousePos : " + mouseMag);
            Debug.Log("firePoint.position + firePoint.up * hitInfo.distance: " + firePoint.position + firePoint.up * hitInfo.distance);
            Debug.Log("firePoint.position + firePoint.up * distance: " + firePoint.position + firePoint.up * distance);
            */

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.up * hitInfo.distance);
        } else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            //lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            lineRenderer.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));
        }

        lineRenderer.enabled = true;

        // wait one frame
        yield return new WaitForSeconds(bulletTrailTime);

        lineRenderer.enabled = false;
    }
}
