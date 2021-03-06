using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEric : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rigidbody;
    Vector2 movement;
    Vector2 mousePos;
    Camera cam;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rigidbody.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }
}
