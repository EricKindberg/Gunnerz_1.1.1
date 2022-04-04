using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    Rigidbody2D rb;
    public List<Transform> waypoints;
    public float maxDistanceDelta = 5f;
    int currentIndex = 0;
    float time = 1f;
    public float rotationSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[currentIndex].position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    private void FixedUpdate()
    {

    }
    public void Move()
    {
        if (currentIndex < waypoints.Count)
        {
            var targetPosition = waypoints[currentIndex].position;
            var movementThisFrame = maxDistanceDelta * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                 (transform.position, targetPosition, movementThisFrame);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1)
            {
                transform.position = targetPosition;
                currentIndex++;

            }
        }
        else
            currentIndex = 0;
    }

    public void ControllingRotation()
    {
        float angle = Mathf.Atan2(waypoints[currentIndex].position.y - transform.position.y,
            waypoints[currentIndex].position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Mathf.LerpAngle(rb.rotation, angle, Time.deltaTime * rotationSpeed);
    }

   

}
