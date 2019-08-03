using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Behavior_Patrol : MonoBehaviour
{
    public Transform[] points;

    private int destPoint = 0;
    private NavMeshAgent agent;
    
    void Start () {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false; // Disabling auto-braking allows for continuous movement between points (ie, the agent doesn't slow down as it pproaches a destination point).
    }

    public void ManualStart(){ 
        //Debug.Log("Starting patrol");
        GotoNextPoint();
    }

    //Turns out player-seeking did not need to manually stop patrol
    // public void ManualStop(){
    //     Debug.Log("Trying to stop patrol, brace for error");
    //     isPatrolling = false;
    // }

    void GotoNextPoint() {
        if(points.Length > 0){
            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination, cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void Update () {
        // Choose the next destination point when the agent gets close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.3f)
            GotoNextPoint();
    }
}