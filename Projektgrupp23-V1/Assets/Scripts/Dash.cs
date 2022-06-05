using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dash : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    [SerializeField] float pushSpeed = 150;
    [SerializeField] GameObject dashParticle;
   

    private bool isDashing;
    private bool canDash = true;
    private float horizontalInput;
    private float verticalInput;
   
    IEnumerator dash;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCoolDown;


    // Making Dash Animation throw making a ghost trial behind the player give the illusion of Dashing fast.
    [SerializeField] float ghostDelay;
    [SerializeField] GameObject ghost;
    public bool makeGhost;
    private float ghostDelaySeconds;
    GameObject currentGhost;

    void Start()
    {
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        ghostDelaySeconds = ghostDelay;
    }
    private void DashAnimation()
    {
        Destroy(currentGhost, 0.3f);
        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                currentGhost = Instantiate(ghost, transform.position, transform.rotation);
                ghostDelaySeconds = ghostDelay;
            }
        }
    }
    public IEnumerator DoDash(float dashDuration, float dashCoolDown)
    {
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rigidbody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

       
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            if (dash != null)
            {
                StopCoroutine(dash);
            }
            dash = DoDash(dashDuration, dashCoolDown);
            StartCoroutine(dash);
            Instantiate(dashParticle, transform.position, Quaternion.identity);
            
        }
        DashAnimation();
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            rigidbody2D.AddForce(new Vector2(horizontalInput * pushSpeed, verticalInput * pushSpeed), ForceMode2D.Force);
            makeGhost = true;
        }
        else
        {
            makeGhost = false;
        }
    }

   
}
