using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float attackRadius;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    private float nextTimeToFire = 0f;
    private Animator animator;
    private Transform playerPos;

     void Start()
    {
        animator = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        Attack();
        float distance = 1.5f;
        if (Vector2.Distance(transform.position,playerPos.position) < distance)
        {
            animator.Play("Alien8_MeleeAttack");
        }
        else
        {
            animator.Play("Alien8_Walking");
        }
       
       
    }
    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);
        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.tag == "Player"&& Time.time > nextTimeToFire)
                {
                    
                    enemy.GetComponent<PlayerHealth>().TakeDamage(damage);
                    nextTimeToFire = Time.time + 1f / fireRate;


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
