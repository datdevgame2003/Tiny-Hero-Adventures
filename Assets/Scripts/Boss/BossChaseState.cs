﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : StateMachineBehaviour
{
    Transform target;
    public float speed = 3;
    Transform borderCheck;
  
    public LayerMask groundLayer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<BossLevel1>().borderCheck;
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null) return;
        Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2, groundLayer) == false)
            animator.SetBool("isChasing", false);

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance <= 1.5f)
            animator.SetBool("isAttacking", true);

       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
