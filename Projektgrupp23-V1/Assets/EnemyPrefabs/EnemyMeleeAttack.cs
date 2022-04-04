using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    public float fireRate = 1f;
    private float nextTimeToFire = 0f;
    public float attackRadius;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }
    private void Attack()
    {
        //Damage the player
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);
        if (hitEnemies != null)
        {

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag == "Player"&& Time.time > nextTimeToFire)
                {
                    enemy.GetComponent<PlayerHealth>().TakeDamage(damage);
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Debug.Log("Hit"+enemy.name);
                }
            }
        }
        //Play animation
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }
}
