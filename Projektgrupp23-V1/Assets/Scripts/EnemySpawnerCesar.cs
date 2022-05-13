using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCesar : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform playerPos;
    public GameObject enemy;
    public int amount;

    private float counter;
    public float spawnRateMiliSec;

    void Start()
    {
        playerPos = FindObjectOfType<PlayerMovement>().transform;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float time = Time.deltaTime;
        counter += Time.deltaTime;
        if (counter >= spawnRateMiliSec)
        {
            SpawnEnemy();
            counter -= spawnRateMiliSec;
        }
    }

    private float Distance(Transform first, Transform second)
    {
        return Vector3.Distance(first.position, second.position);
    }

    private Transform GetSpawnLoacation()
    {
        Transform children = GetComponent<Transform>();
        Transform closestSpawnNotInsideCameraView = null;


        foreach (Transform child in transform)
        {
            if (Distance(playerPos, child) >= 12.0f)
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
                GameObject newEnemy = Instantiate(enemy, GetSpawnLoacation().position, Quaternion.identity);
                amount--;
            }
            catch
            {
                Debug.LogError("ERROR SPAWINING ENEMY!");
            }
        }
    }
}
