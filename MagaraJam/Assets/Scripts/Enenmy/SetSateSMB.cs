using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSateSMB : StateMachineBehaviour
{
    public int numberAnimationRandom;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        int randState = Random.Range(1, numberAnimationRandom + 1);

        animator.SetInteger(TagManager.RANDOM_PARAMETER, randState);

    }
}
