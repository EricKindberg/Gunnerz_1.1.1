using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    Animator animation;
    [SerializeField] Sprite deathSprite;
    [SerializeField] GameObject loot;

    private void Start()
    {
        animation = GetComponent<Animator>();
    }
    public void TakingDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            HandleDeath();
        }
        else
        {
            animation.Play("TakeDamage");
        }
    }

    public void HandleDeath()
    {
        UpdateDeathGraphics();
        RemoveColliders();
        SpawnLoot();
    }

    public void UpdateDeathGraphics()
    {
        animation.Play("Die");
        gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;

    }

    public void RemoveColliders()
    {
        if (gameObject.GetComponent<CircleCollider2D>() != null)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        if (gameObject.GetComponent<BoxCollider2D>() != null)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void SpawnLoot()
    {
        if (loot != null)
        {
            Instantiate(loot, transform.position, Quaternion.identity);
        }
    }
}
