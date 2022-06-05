using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(2f, 20f)] [SerializeField] float moveSpeed = 5f;
    [Range(2.5f,6.5f)] [SerializeField] float rotationOffset = 5f;

    Rigidbody2D rigidbody;
    Camera camera;
    Vector2 movement;
    Vector2 mousePos;
    GameObject coffeeBuffButton;
    bool coffeeActive; //Coffe is used as a movementspeed boost
    float coffeeDuration = 0;
    float coffeeMaxDuration = 60;
    float coffeeBuff = 0;
    public Texture2D mouseCursor;
    public int mouseOffset;
  
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = FindObjectOfType<Camera>();
        coffeeBuffButton = GameObject.Find("Coffee");
        coffeeBuffButton.SetActive(false);
        Cursor.SetCursor(mouseCursor, new Vector2(mousePos.x - mouseOffset, mousePos.y - mouseOffset), CursorMode.ForceSoftware);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        UpdatingDirection();

        CoffeeUpdate();
    }

    void CoffeeUpdate()
    {
        if (coffeeActive == false)
        {
            return;
        }
        if (coffeeDuration >= coffeeMaxDuration)
        {
            coffeeBuffButton.SetActive(false);
            coffeeActive = false;
            moveSpeed -= coffeeBuff;
        }
        else
        {
            coffeeDuration += Time.deltaTime;
        }
    }

    public void IncreaseMoveSpeed(float aValue)
    {
        coffeeBuffButton.SetActive(true);
        coffeeActive = true;
        coffeeBuff = aValue;
        coffeeDuration = 0;
        moveSpeed += aValue;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
    private void UpdatingDirection()
    {
        Vector2 aimDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }
}
