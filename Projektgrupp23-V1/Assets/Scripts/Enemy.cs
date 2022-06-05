using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int scoreValue = 10;

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
        try
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerScore>().addToScore(scoreValue);
        } catch
        {
            Debug.Log("Failed to add to score!");
        }
        Destroy(gameObject);
    }
}
