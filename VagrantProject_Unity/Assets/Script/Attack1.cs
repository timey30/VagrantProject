﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : StateMachineBehaviour
{
    
    public float variable;
    public GameObject player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

          player = GameObject.FindGameObjectWithTag("Player");
        variable = player.GetComponent<Playerattack>().noOfClicks;
        animator.SetBool("At1", false);
        //variable = player.GetComponent<Playerattack>().noOfClicks;
    }


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            variable++;
            animator.SetBool("At1", false);
            if (variable >= 2)
            {
                
                animator.SetBool("At2", true);
                Debug.Log("At2");
                player.GetComponent<Playerattack>().Damage();
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
