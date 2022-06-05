
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwoBehaviour : StateMachineBehaviour
{

    private int i = 0;
    private const int amount_Of_Time_To_Transtion = 60;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        i++;
        if (i > amount_Of_Time_To_Transtion)
            animator.Play("StageThreeBehaviour");
    }

}

