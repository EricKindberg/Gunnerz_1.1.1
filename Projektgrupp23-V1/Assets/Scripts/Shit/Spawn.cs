using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Spawn : MonoBehaviour
{
    public float range;
    private GameObject player;
    private List<GameObject> enemyTypes;
    private int etIndex; //enemyTypesIndex
    private int enemyTypeChange = 3;
    private GameObject spawnedEnemy;
    private SpawnSharedInfo sharedInfo;
    public void Initalize(Transform t, List<GameObject> enemies, GameObject player, SpawnSharedInfo sharedInfo)
    {
        enemyTypes = enemies;
        this.player = player;
        this.sharedInfo = sharedInfo;
        GetComponent<Transform>().position = t.position;
    }

    public bool CanSpawn()
    {
        if (Vector2.Distance(transform.position, player.GetComponent<Rigidbody2D>().position) <= range)
        {
            return false;
        }
        else return true;
    }

    public void SpawnEnemies()
    {
        int k=0;
        while (true)//(CanSpawn() && sharedInfo.TotalNrEnemiesToSpawn>0)
        {
            SkippingEnemiesNotToSpawn();
            spawnedEnemy = Instantiate(enemyTypes[etIndex], transform);
            DecrementingEnemies();
            k++;
            if (k >= enemyTypeChange)
            {
                etIndex++;
                k = 0;
                if (etIndex >= enemyTypes.Count)
                {
                    etIndex = 0;
                }
            }
        }
    }

    private void SkippingEnemiesNotToSpawn()
    {
        if (sharedInfo.MovingEnemiesToSpawn < 1 && etIndex == 0)
        {
            etIndex++;
        }
        if (sharedInfo.StaticEnemiesToSpawn < 1 && etIndex == 1)
        {
            etIndex++;
        }
        if (sharedInfo.BossEnemiesToSpawn < 1 && etIndex == 2)
        {
            etIndex++;
        }
    }
    private void DecrementingEnemies()
    {
        sharedInfo.enemiesToSpawnMutex.WaitOne();
        if (etIndex == 0)
        {
            sharedInfo.MovingEnemiesToSpawn--;
        }
        else if (etIndex == 1)
        {
            sharedInfo.StaticEnemiesToSpawn--;
        }
        else if (etIndex == 2)
        {
            sharedInfo.BossEnemiesToSpawn--;
        }
        sharedInfo.TotalNrEnemiesToSpawn = sharedInfo.MovingEnemiesToSpawn +
            sharedInfo.StaticEnemiesToSpawn + sharedInfo.BossEnemiesToSpawn;
        sharedInfo.enemiesToSpawnMutex.ReleaseMutex();
    }


    /*
     * [Range (2f, 10f)] public float spawnRate = 5f;
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
    }*/


   
}
