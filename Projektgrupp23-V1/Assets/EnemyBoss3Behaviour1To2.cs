using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss3Behaviour1To2 : StateMachineBehaviour
{
    private EnemyHealth enemyHealth;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyHealth = animator.GetComponent<EnemyHealth>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int healthBossSpeed = 30;
        enemyHealth.health += healthBossSpeed * Time.fixedDeltaTime; 
        if (enemyHealth.health >=199)
        {
            animator.Play("EnemyBoss3_Behaviour2 ");
        }

        if (animator.GetComponentInChildren<HealthBar>() != null)
        {
            animator.GetComponentInChildren<HealthBar>().hp = enemyHealth.health;
        }
    }




}
