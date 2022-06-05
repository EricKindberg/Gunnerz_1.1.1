using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SpawnHandler : MonoBehaviour
{
    private float timer;
    private float currrentTime;
    List<Spawn> spawnPoints;
    public List<Transform> transforms;
    public GameObject MovingEnemy;
    public GameObject StaticEnemy;
    public GameObject BossEnemy;
    public GameObject Player;
    List<GameObject> enemies;
    private Spawn spawn;
    private SpawnSharedInfo sharedInfo;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<Spawn>();
        timer = 5f;
        spawnPoints = new List<Spawn>();
        enemies = new List<GameObject>();
        enemies.Add(MovingEnemy);
        enemies.Add(StaticEnemy);
        enemies.Add(BossEnemy);

        sharedInfo = GetComponent<SpawnSharedInfo>();
        sharedInfo.Initialize();

        for(int i = 0; i<transforms.Count; i++)
        {
            Spawn s = Instantiate(GetComponent<Spawn>());
            s.Initalize(transforms[i], enemies, Player, sharedInfo);
            spawnPoints.Add(s);
           // Thread thread = new Thread(s.SpawnEnemies);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (Spawn s in spawnPoints)
        {
            s.SpawnEnemies();
        }   */
    }
}
