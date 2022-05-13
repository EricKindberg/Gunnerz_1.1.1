using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range (2f, 10f)] public float spawnRate = 5f;
    public GameObject Enemy;
    public int amount;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(amount>0)
        {
            // Spawn Enemy
            Enemy = Instantiate(Enemy, gameObject.transform);
            amount--;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
