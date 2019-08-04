using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Anim_Flipper : MonoBehaviour
{
    Rigidbody rigidbody;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(rigidbody.velocity.x > .1){
            animator.SetFloat("MovingRight", rigidbody.velocity.x);
        }else if(rigidbody.velocity.x < -.1){
            animator.SetFloat("MovingLeft", rigidbody.velocity.x);
        }else if (rigidbody.velocity.y > .1){
            animator.SetFloat("MovingNorth", rigidbody.velocity.y);
        }else if (rigidbody.velocity.y < -.1){
            animator.SetFloat("MovingSouth", rigidbody.velocity.y);
        }
    }
}
