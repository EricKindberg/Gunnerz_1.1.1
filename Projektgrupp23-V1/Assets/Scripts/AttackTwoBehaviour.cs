using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTwoBehaviour : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rigidbody;
    private EnemyHealth enemyHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] float offset;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemyHealth = animator.GetComponent<EnemyHealth>();
    }

  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = player.position - animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - offset;
        rigidbody.rotation = angle;

        direction.Normalize();
        rigidbody.MovePosition(animator.transform.position
                                        + (direction * moveSpeed * Time.fixedDeltaTime));
        if (enemyHealth.health <= 0)
        {
            Destroy(animator.gameObject);
        }
    }
}
