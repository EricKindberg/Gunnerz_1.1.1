using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(2f, 20f)] public float moveSpeed = 5f;
    [Range(2.5f,6.5f)] public float rotationOffset = 5f;
    
    public Rigidbody2D rb;
    public Camera cam;


    Vector2 movement;
    Vector2 mousePos;


   


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        Vector2 aimDir = mousePos - rb.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        

    }

    public void IncreaseMoveSpeed(float aValue)
    {
        moveSpeed += aValue;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
