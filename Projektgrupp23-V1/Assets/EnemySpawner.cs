using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range (2f, 10f)] public float spawnRate = 5f;
    public GameObject Enemy;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            // Spawn Enemy
            Enemy = Instantiate(Enemy, gameObject.transform);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
