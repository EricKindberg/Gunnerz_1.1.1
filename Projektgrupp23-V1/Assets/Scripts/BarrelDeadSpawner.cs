using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDeadSpawner : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.enabled = false;
    }
}
