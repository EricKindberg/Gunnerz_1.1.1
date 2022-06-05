using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;

    void Update()
    {
        transform.position = playerPos.position + new Vector3(0, 0, -10);
    }
}
