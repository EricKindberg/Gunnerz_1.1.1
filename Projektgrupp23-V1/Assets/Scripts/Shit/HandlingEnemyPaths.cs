using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HandlingEnemyPaths : MonoBehaviour
{
    public Seeker seeker;
    public AIDestinationSetter destinationSetter;
    public EnemyPathing enemyPathing;
    public AIPath aiPath;
    public Transform target;
    public float seekingRadius;

    // Start is called before the first frame update
    void Start()
    {
        /*seeker = GetComponent<Seeker>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        enemyPathing = GetComponent<EnemyPathing>();*/
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) < seekingRadius)
        {
            destinationSetter.target = target;
            aiPath.enabled = true;
            //aiPath.isStopped = false;
          //  aiPath.enableRotation = true;
        }
        else if(Vector2.Distance(transform.position, target.position) >= seekingRadius)
        {
            enemyPathing.Move();
            enemyPathing.ControllingRotation();
            destinationSetter.target = null;
            aiPath.enabled = false;
           // aiPath.isStopped = true;
           // aiPath.enableRotation = false;
            //seeker.enabled = false;
            //seeker.CancelInvoke();
        }
    }
}
