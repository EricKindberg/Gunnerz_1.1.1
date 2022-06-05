using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOneBehaviour : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rigidbody;
    private EnemyHealth enemyHealth;
    [SerializeField] float offset;
    private int health;
  

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemyHealth = animator.GetComponent<EnemyHealth>();
        health = 100;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        Vector3 direction = player.position - animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - offset ;
        rigidbody.rotation = angle;

        if (enemyHealth.health <= health)
        {
            animator.Play("AttackTwo");
        }
    }
}
