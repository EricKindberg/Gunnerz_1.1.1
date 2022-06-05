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
    AIDestinationSetter aIDestinationSetter;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemyHealth = animator.GetComponent<EnemyHealth>();
        //aIDestinationSetter = animator.GetComponent<AIDestinationSetter>();
        //aIDestinationSetter.target = player;
    }

  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 diraction = player.position - animator.transform.position;
        float angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg - offset;
        rigidbody.rotation = angle;

        diraction.Normalize();
        rigidbody.MovePosition(animator.transform.position
                                        + (diraction * moveSpeed * Time.fixedDeltaTime));
        if (enemyHealth.health <= 0)
        {
            Destroy(animator.gameObject);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
