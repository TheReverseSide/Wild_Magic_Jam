using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Guard_Anim_Flipper : MonoBehaviour
{
    //Rigidbody rigidbody;
    public Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("Velocity" + agent.velocity);

        if(agent.velocity.x > .9){
            animator.SetFloat("MovingRight", agent.velocity.x);
        } else if(agent.velocity.x < -.9){
            animator.SetFloat("MovingLeft", agent.velocity.x);
        }
        if (agent.velocity.y > .9){
            animator.SetFloat("MovingNorth",agent.velocity.y);
        } else if(agent.velocity.y < -.9){
            animator.SetFloat("MovingSouth", agent.velocity.y);
        }
    }
}
