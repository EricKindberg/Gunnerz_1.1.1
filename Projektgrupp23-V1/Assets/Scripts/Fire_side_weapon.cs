using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_side_weapon : MonoBehaviour
{
    public Transform firePoint;
    public Camera cam;

    //public GameObject muzzleFlashePrefab;
    //public Transform muzzelFlashPos;

    public float projectileForce = 20f;
    public int WeaponDamage = 10;
    public float accuracy = 0f;

    [Range(0.01f, 1f)] public float rateOfFire = 0.2f;

    public GameObject projectilePrefab;
    public GameObject bullet_trail_line;
    public GameObject muzzleFlashePrefab;
    private GameObject muzzleFlashOBJ;
    private MuzzelFlash muzzelFlashSCR;

    Coroutine firingCoroutine;

    private void Start()
    {
        Debug.Log("What");
        cam = FindObjectOfType<Camera>();
        //muzzelFlashSCR = muzzleFlashOBJ.GetComponent<MuzzelFlash>();
        //muzzleFlash();
        //muzzleFlashOBJ.transform.position = firePoint.transform.position;
        //muzzleFlashOBJ.transform.rotation = firePoint.transform.rotation;
        //muzzleFlashOBJ.transform.localScale = firePoint.transform.localScale;
        muzzleFlashOBJ = Instantiate(muzzleFlashePrefab, firePoint);
        muzzelFlashSCR = muzzleFlashOBJ.GetComponent<MuzzelFlash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {

            //muzzleFlash();
            Fire();
            firingCoroutine = StartCoroutine(Fire());
        }
        if (Input.GetButtonUp("Fire2"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    void AnimateMuzzleFlash()
    {
        //muzzelFlashSCR.ResetAnimation();

        /*
        Quaternion fireRotation = firePoint.rotation * Quaternion.Euler(-180, 90, -90);
        //Vector3 muzzelFlashPos = firePoint.position;
        //GameObject flash = Instantiate(muzzleFlashePrefab, muzzelFlashPos, fireRotation, firePoint);
        //flash.transform.position += new Vector3(0.612f, 0.268f, 0f);
        //GameObject flash = Instantiate(muzzleFlashePrefab, muzzelFlashPos.position, fireRotation, firePoint.transform);
        GameObject flash = Instantiate(muzzleFlashePrefab, firePoint);
        */
        //GameObject flash = Instantiate(muzzleFlashePrefab, firePoint);
    }

    IEnumerator Fire()
    {

        while (true)
        {
            AnimateMuzzleFlash();
            //float distance = Vector3.Distance(firePoint.position, Input.mousePosition);

            //Quaternion fireRotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);
            // Because the Bullet asset is laying sideways I had to rotate the bullet 90%

            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);

            //lineRenderer.enabled = true;

            yield return new WaitForSeconds(rateOfFire);
            // wait one frame

        }
    }
}
