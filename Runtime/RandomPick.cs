using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPick : StateMachineBehaviour
{
    readonly float animMinTime = 1;
    readonly float animMaxTime = 3;
    float animTimer = 0;
    List<string> listTriggers = new List<string>();

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        if (animTimer <= 0)
        {
            RandomAnim(animator);
            animTimer = Random.Range(animMinTime, animMaxTime);
        }
        else
        {
            animTimer -= Time.deltaTime;
        }
    }
    void RandomAnim (Animator animator)
    {
        // Take all parameters from Animator
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            listTriggers.Add(parameter.name);
        }
        // Convert list to array
        string[] animTriggers = listTriggers.ToArray();
        System.Random rnd = new System.Random();
        int animPosition = rnd.Next(animTriggers.Length);
        string animTrigger = animTriggers[animPosition];
        animator.SetTrigger(animTrigger);
    }
    
}
