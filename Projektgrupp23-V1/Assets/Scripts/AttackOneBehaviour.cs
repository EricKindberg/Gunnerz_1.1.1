using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOneBehaviour : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rigidbody;
    private EnemyHealth enemyHealth;
    private Animator animator;
    [SerializeField] float offset;
  

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody = animator.GetComponent<Rigidbody2D>();
        enemyHealth = animator.GetComponent<EnemyHealth>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        Vector3 diraction = player.position - animator.transform.position;
        float angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg - offset ;
        rigidbody.rotation = angle;

        if (enemyHealth.health <= 100)
        {
            animator.Play("AttackTwo");
        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
