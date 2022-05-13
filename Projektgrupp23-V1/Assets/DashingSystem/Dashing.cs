using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dashing : MonoBehaviour
{

    public Rigidbody2D _Rigidbody2D;
    public GameObject dashParticle;
    PalyerGhost palyerGhost; 

    private bool isDashing;
    private bool canDash = true;
    private float horizontalInput;
    private float verticallInput;
    private float horizontalDirication;
    private float verticallDirication;
    IEnumerator dash;
    public float dashDurtion;
    public float dashCoolDown;


    void Start()
    {
        palyerGhost = GetComponent<PalyerGhost>();
    }
    public IEnumerator DoDash(float dashDurtion, float dashCoolDown)
    {
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashDurtion);
        isDashing = false;
        _Rigidbody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticallInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0)
        {
            horizontalDirication = horizontalInput;
        }
        if (verticallInput != 0)
        {
            verticallDirication = verticallInput;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            if (dash != null)
            {
                StopCoroutine(dash);
            }
            dash = DoDash(dashDurtion, dashCoolDown);
            StartCoroutine(dash);
            Instantiate(dashParticle, transform.position, Quaternion.identity);
            
        }
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            _Rigidbody2D.AddForce(new Vector2(horizontalDirication * 3, verticallInput * 3), ForceMode2D.Impulse);
            palyerGhost.makeGhost = true;
        }
        else
        {
            palyerGhost.makeGhost = false;
        }
    }

   
}
