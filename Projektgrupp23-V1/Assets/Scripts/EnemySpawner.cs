using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int amount;
    private float counter;
    [SerializeField] float spawnRateSec;
    [SerializeField] float range;
    void Start()
    {
        playerPos = FindObjectOfType<PlayerMovement>().transform;
        counter = 0;
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= spawnRateSec)
        {
            SpawnEnemy();
            counter -= spawnRateSec;
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
                if (enemyPrefab!=null)
                {
                    GameObject newEnemy = Instantiate(enemyPrefab, GetSpawnLocation().position, Quaternion.identity);
                    amount--;
                }
        }
    }
    private float Distance(Transform first, Transform second)
    {
        return Vector3.Distance(first.position, second.position);
    }
}
