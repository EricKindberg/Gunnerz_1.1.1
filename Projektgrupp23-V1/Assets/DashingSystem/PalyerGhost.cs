using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalyerGhost : MonoBehaviour
{
    public float ghostDelay;
    public GameObject ghost;
    public bool makeGhost;
    private float ghostDelaySeconds;
    GameObject currentGhost;
    void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    
    void Update()
    {
        Destroy(currentGhost, 0.3f);
        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                currentGhost = Instantiate(ghost, transform.position, transform.rotation);
                ghostDelaySeconds = ghostDelay;
              
            }
        }
       
    }
}
