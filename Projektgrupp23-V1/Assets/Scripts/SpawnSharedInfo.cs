using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class SpawnSharedInfo : MonoBehaviour
{
    public int TotalNrEnemiesToSpawn;
    public int MovingEnemiesToSpawn;
    public int StaticEnemiesToSpawn;
    public int BossEnemiesToSpawn;
    public bool ContinueSpawning;
    public System.Random rand;
    public Mutex enemiesToSpawnMutex;
    //public Semaphore maxEnemiesToSpawn;
    public void Initialize()
    {
        enemiesToSpawnMutex = new Mutex();
        rand = new System.Random();
        MovingEnemiesToSpawn = 10;
        StaticEnemiesToSpawn = 5;
        BossEnemiesToSpawn = 1;
        TotalNrEnemiesToSpawn = MovingEnemiesToSpawn + StaticEnemiesToSpawn + BossEnemiesToSpawn;
        //maxEnemiesToSpawn = new Semaphore(TotalNrEnemiesToSpawn,TotalNrEnemiesToSpawn);
    }
}
