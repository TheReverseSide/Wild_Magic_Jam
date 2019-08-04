using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InputInterpretation : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MovingRight", agent.velocity.x);
        animator.SetFloat("MovingLeft", agent.velocity.x);

        animator.SetFloat("MovingNorth", agent.velocity.z);
        animator.SetFloat("MovingSouth", agent.velocity.z);

        animator.SetBool("Static", Mathf.Abs(agent.velocity.x + agent.velocity.z) <= 0.01f);
    }
}
