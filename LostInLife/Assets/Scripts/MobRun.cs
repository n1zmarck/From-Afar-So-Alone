using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody rb;
    public float speed = 2.5f;
    public float attackRange = 4f;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.GetComponent<Rigidbody>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        animator.GetComponent<MobLook>().LookAtPlayer();

        Vector3 target = new Vector3(player.position.x, rb.position.y, player.position.z);
        //Vector3 correctedTarget = target - 
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        // add in navmesh
        rb.MovePosition(newPos);


        if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Shoot");
        }
    }


}
