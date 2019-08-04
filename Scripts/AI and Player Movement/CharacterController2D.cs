using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .2f;  // How much to smooth out the movement
    private Rigidbody m_Rigidbody2D;
    // private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Animation Stuff")]
    [Space]
    public Animator animator;


    //Part of simpler movement
    float horizontalInput;
    float verticalInput;

    float diagMoveLimiter = 0.7f;
    public float runSpeed = 3.0f;

    float crouchMoveLimiter = .5f;
    bool isCrouched;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); 
    }

    private void Update(){
        // Gives a value between -1 and 1
        horizontalInput = Input.GetAxisRaw("Horizontal"); // -1 is left
        verticalInput = Input.GetAxisRaw("Vertical"); // -1 is down

        if(Input.GetAxisRaw("Crouch") > .01){
            isCrouched = true;
            Debug.Log("Crouching, should decrement speed...");
        }else {isCrouched = false;}
    }

    private void FixedUpdate()
    {
        Move(horizontalInput * Time.fixedDeltaTime, verticalInput * Time.fixedDeltaTime, isCrouched);
    }

    public void Move(float moveHor, float moveVert, bool isCrouched)
    {
        Vector3 targetVelocity;
        // If crouching, check to see if the character can stand up
        // if (!isCrouched)
        // {
        //     // If the character has a ceiling preventing them from standing up, keep them crouching
        //     if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
        //     {
        //         isCrouched = true;
        //     }
        // }

        // If crouching
        if (isCrouched)
        {
            horizontalInput *= crouchMoveLimiter;
            verticalInput *= crouchMoveLimiter; 
            animator.SetBool("isCrouching", true);
        }else animator.SetBool("isCrouching", false);

        if (horizontalInput != 0 && verticalInput != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontalInput *= diagMoveLimiter;
            verticalInput *= diagMoveLimiter;

            targetVelocity = new Vector3(horizontalInput * runSpeed, 0,verticalInput * runSpeed);
        }else{
            targetVelocity = new Vector3(horizontalInput * runSpeed, 0,verticalInput * runSpeed);
        }

        // Debug.Log("Hor speed: " + horizontalInput + "Vert speed: " + verticalInput);

        animator.SetFloat("MovingRight", horizontalInput);
        animator.SetFloat("MovingLeft", horizontalInput);

        animator.SetFloat("MovingNorth", verticalInput);
        animator.SetFloat("MovingSouth", verticalInput);

        animator.SetBool("Static", horizontalInput + verticalInput == 0);

        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); //ref m_Velocity - what is that???
    }
}