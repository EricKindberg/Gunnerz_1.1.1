using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(2f, 20f)] [SerializeField] float moveSpeed = 5f;
    [Range(2.5f,6.5f)] [SerializeField] float rotationOffset = 5f;

    Rigidbody2D rigidbody;
    Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    GameObject coffeeBuffButton;
    bool coffeActive;
    float coffeeDuration = 0;
    float coffeMaxDuration = 60;
    float coffeeBuff = 0;
    public Texture2D mouseCursor;
    public int mouseOffset;
  
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        coffeeBuffButton = GameObject.Find("Coffee");
        coffeeBuffButton.SetActive(false);
        Cursor.SetCursor(mouseCursor, new Vector2(mousePos.x - mouseOffset, mousePos.y - mouseOffset), CursorMode.ForceSoftware);

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;

        CoffeeUpdate();
       
    }

    void CoffeeUpdate()
    {
        if (coffeActive == false)
        {
            return;
        }
        if (coffeeDuration >= coffeMaxDuration)
        {
            coffeeBuffButton.SetActive(false);
            coffeActive = false;
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
        coffeActive = true;
        coffeeBuff = aValue;
        coffeeDuration = 0;
        moveSpeed += aValue;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
