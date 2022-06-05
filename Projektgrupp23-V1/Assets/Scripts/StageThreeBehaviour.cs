
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageThreeBehaviour : StateMachineBehaviour
{

    private Transform player;
    private Rigidbody2D rigidbody;
    private EnemyHealth enemyHealth;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float offset;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemyHealth = animator.GetComponent<EnemyHealth>();


    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 dir = player.position - animator.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - offset;
        rigidbody.rotation = angle;
        dir.Normalize();

        rigidbody.MovePosition((Vector2)animator.transform.position + (dir * moveSpeed * Time.fixedDeltaTime));

        if (enemyHealth.health <= 1)
        {
            Destroy(animator.gameObject);
        }

    }

}

