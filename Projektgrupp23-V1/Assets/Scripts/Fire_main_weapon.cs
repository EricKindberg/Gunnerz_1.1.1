using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_main_weapon : MonoBehaviour
{
    public Transform firePoint;
    public Camera cam;

    //public GameObject muzzleFlashePrefab;
    //public Transform muzzelFlashPos;

    public float bulletForce = 20f;
    public int WeaponDamage = 10;

    [Range(0.01f, 1f)] public float rateOfFire = 0.2f;

    public float accuracy = 0f;

    public GameObject bullet_trail_line;
    public GameObject muzzleFlashePrefab;
    private GameObject muzzleFlashOBJ;
    private MuzzelFlash muzzelFlashSCR;
    //public Transform muzzelFlashPos;

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
        if (Input.GetButtonDown("Fire1"))
        {
            
            //muzzleFlash();
            Fire();
            firingCoroutine = StartCoroutine(Fire());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            

        }
    }

    void AnimateMuzzleFlash()
    {
        muzzelFlashSCR.ResetAnimation();

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
        // Fire coroutine was inspired by unity course project "Laser Defender"

        while (true)
        {
            GameObject line = Instantiate(bullet_trail_line, firePoint);
            LineRenderer lineRenderer = line.GetComponent<LineRenderer>();

            AnimateMuzzleFlash();


            float distance = Vector3.Distance(firePoint.position, Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.HandleDamage(WeaponDamage);
                }

                /*
                Debug.Log("Firepoint Pos: " + firePoint.position);
                Debug.Log("MousePos : " + mouseMag);
                Debug.Log("firePoint.position + firePoint.up * hitInfo.distance: " + firePoint.position + firePoint.up * hitInfo.distance);
                Debug.Log("firePoint.position + firePoint.up * distance: " + firePoint.position + firePoint.up * distance);
                */
                /*
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.up * hitInfo.distance);
                */
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.up * hitInfo.distance);

            }
            else
            {
                /*
                lineRenderer.SetPosition(0, firePoint.position);
                //lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
                lineRenderer.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));
                */
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));
            }

            //lineRenderer.enabled = true;

            yield return new WaitForSeconds(rateOfFire);
            // wait one frame

        }
    }
}
