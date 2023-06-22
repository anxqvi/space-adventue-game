using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolBehavior : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    string currentScene;

    Transform player;
    float chaseRange=15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level1")
        {
            timer=0;
        
            Transform wayPointsObject=GameObject.FindGameObjectWithTag("WayPoints").transform;
            
            foreach(Transform t in wayPointsObject)
        
            wayPoints.Add(t);
        
            agent = animator.GetComponent<NavMeshAgent>();
            agent.SetDestination(wayPoints[0].position);
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentScene == "Level1")
        {
            if(agent.remainingDistance<=agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0,wayPoints.Count)].position);
         
            timer+=Time.deltaTime;
            if(timer>10)//if timer is greater than ten seconds then enter to idle state
            animator.SetBool("isPatrolling",false);

            float distance=Vector3.Distance(animator.transform.position,player.position);
       
            if(distance<chaseRange)
            animator.SetBool("isChasing",true);
        }

         
    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentScene == "Level1")
        {
            agent.SetDestination(agent.transform.position);
        }
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

