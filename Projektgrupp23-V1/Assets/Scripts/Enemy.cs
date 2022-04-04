using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int health = 100;

    void Start()
    {
        
    }

    public void HandleDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
