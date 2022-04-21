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
        // TODO: Move the button listner event to a seperate player fire script. 
        // The logic which handles the fire event should still remains here!
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

        /*
        Så som koden är skriven kan spelaren överstiga rateOfFire om
        de klickar snabbaren. För att undvika detta möste perioden mellan
        varje skottlosning att sparas. Om tiden mellan den senaste och nya 
        skottlossningen är kortare än skjuthastighet bör  
        skottlossningen förhindras.
         */
    }

    void AnimateMuzzleFlash()
    {
        muzzelFlashSCR.ResetAnimation();
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
                if (hitInfo.transform.gameObject.tag == "Enemy")
                {
                    hitInfo.transform.gameObject.GetComponent<EnemyHealth>().TakingDamage(WeaponDamage);
                    //enemy.HandleDamage(bulletDamage);
                }

                // Bullet trail
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.up * hitInfo.distance);

            }
            else
            {
                // Prevents the bullet trail from going to far when not hitting anything
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));
            }


            yield return new WaitForSeconds(rateOfFire);
            // wait rateOfFire between loop

        }
    }
}
