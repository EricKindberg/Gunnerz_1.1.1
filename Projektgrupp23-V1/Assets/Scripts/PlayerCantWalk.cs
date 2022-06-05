using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCantWalk : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }
}
