using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chug_run : StateMachineBehaviour{

    public float speed = 2.5f; 
    private Transform player;
    private Rigidbody2D rigidbody; 
    private Chug_flip flipSprite; 
    public float minimumDistanceToAttack = 1f; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        //Get the array of objects that fall under Player 
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform; 
        rigidbody = animator.GetComponent<Rigidbody2D>(); 
        flipSprite = animator.GetComponent<Chug_flip>(); 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){

        flipSprite.flipping(); 

        Vector2 target = new Vector2(player.position.x, rigidbody.position.y); 
        Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPos);

        if(Vector2.Distance(player.position, rigidbody.position) < minimumDistanceToAttack/2){
            animator.SetTrigger("attacking"); 
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
        animator.ResetTrigger("attacking"); 
    }
}
