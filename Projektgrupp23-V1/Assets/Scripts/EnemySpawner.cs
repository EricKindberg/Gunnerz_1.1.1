using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] GameObject enemy;
    [SerializeField] int amount;
    private float counter;
    [SerializeField] float spawnRateMiliSec;
    [SerializeField] float range;
    void Start()
    {
        playerPos = FindObjectOfType<PlayerMovement>().transform;
        counter = 0;
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= spawnRateMiliSec)
        {
            SpawnEnemy();
            counter -= spawnRateMiliSec;
        }
    }

    private Transform GetSpawnLocation()
    {
        Transform closestSpawnNotInsideCameraView = null;

        foreach (Transform child in transform)
        {
            if (Distance(playerPos, child) >= range)
            {
                if (closestSpawnNotInsideCameraView == null)
                {
                    closestSpawnNotInsideCameraView = child;
                }

                if (Distance(playerPos, closestSpawnNotInsideCameraView) > Distance(playerPos, child))
                {
                    closestSpawnNotInsideCameraView = child;
                }
            }
        }

        return closestSpawnNotInsideCameraView;
    }

    private void SpawnEnemy()
    {
        if (amount > 0)
        {
            try
            {
                GameObject newEnemy = Instantiate(enemy, GetSpawnLocation().position, Quaternion.identity);
                amount--;
            }
            catch
            {
                Debug.LogError("ERROR SPAWINING ENEMY!");
            }
        }
    }
    private float Distance(Transform first, Transform second)
    {
        return Vector3.Distance(first.position, second.position);
    }
}
