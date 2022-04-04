using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakingDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);


        }
    }


}
