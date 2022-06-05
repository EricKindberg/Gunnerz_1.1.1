using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float maxDistanceDelta = 5f;
    [SerializeField] float rotationSpeed = 8f;
    int currentIndex = 0;

    void Start()
    {
        transform.position = waypoints[currentIndex].position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        if (currentIndex < waypoints.Count)
        {
            var targetPosition = waypoints[currentIndex].position;
            var movementThisFrame = maxDistanceDelta * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
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
        rigidbody.rotation = Mathf.LerpAngle(rigidbody.rotation, angle, Time.deltaTime * rotationSpeed);
    }



}
