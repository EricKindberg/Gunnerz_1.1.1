using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_side_weapon : MonoBehaviour
{
    public Transform firePoint;
    public Camera cam;
    public AudioSource shootSound;

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

    GameObject ammoUI;

    Coroutine firingCoroutine;

    int ammo;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        ammoUI = GameObject.Find("Ammo");
        //muzzelFlashSCR = muzzleFlashOBJ.GetComponent<MuzzelFlash>();
        //muzzleFlash();
        //muzzleFlashOBJ.transform.position = firePoint.transform.position;
        //muzzleFlashOBJ.transform.rotation = firePoint.transform.rotation;
        //muzzleFlashOBJ.transform.localScale = firePoint.transform.localScale;
        muzzleFlashOBJ = Instantiate(muzzleFlashePrefab, firePoint);
        muzzelFlashSCR = muzzleFlashOBJ.GetComponent<MuzzelFlash>();

        SetAmmo();
    }

    public void SetAmmo()
    {
        switch (gameObject.name)
        {
            case "SW 0":
                ammo = 5;
                break;
            case "SW 1":
                ammo = 5;
                break;
            case "SW 2":
                ammo = 30;
                break;
            case "SW 3":
                ammo = 20;
                break;
            case "SW 4":
                ammo = 15;
                break;
            case "SW 5":
                ammo = 15;
                break;
            case "SW 6":
                ammo = 15;
                break;
            case "SW 7":
                ammo = 15;
                break;
            case "SW 8":
                ammo = 15;
                break;
            case "SW 9":
                ammo = 15;
                break;
            case "SW 10":
                ammo = 15;
                break;
            case "SW 11":
                ammo = 15;
                break;
            case "SW 12":
                ammo = 15;
                break;
            case "SW 13":
                ammo = 15;
                break;
            default:
                break;
        }

        ammoUI.GetComponent<TMPro.TextMeshProUGUI>().text = ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (ammo > 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                //muzzleFlash();

                Fire();
                firingCoroutine = StartCoroutine(Fire());

            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            if (firingCoroutine != null)
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


            ammo--;

            ammoUI.GetComponent<TMPro.TextMeshProUGUI>().text = ammo.ToString();

            if (ammo == 0)
            {
                SetAmmo();
                gameObject.SetActive(false);

                GameObject player = GameObject.FindWithTag("Player");
                PickUpWeapon pickUpWeapon = player.GetComponent<PickUpWeapon>();
                pickUpWeapon.weapon_Number = -1;

                ammoUI.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            }


            if (shootSound != null)
            {
                shootSound.Play();

            }
            //lineRenderer.enabled = true;

            yield return new WaitForSeconds(rateOfFire);
            // wait one frame

        }
    }
}
