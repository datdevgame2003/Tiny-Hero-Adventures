using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2IdleState : StateMachineBehaviour
{
    Transform target;
    Transform borderCheck;
    public LayerMask groundLayer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<BossLevel2>().borderCheck;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null) return;

        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2, groundLayer) == false)
            return;

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 7)
            animator.SetBool("isChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void /*OnStateExit*/(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    AudioManager.instance.Play("ZombieScream");
    //}
}
