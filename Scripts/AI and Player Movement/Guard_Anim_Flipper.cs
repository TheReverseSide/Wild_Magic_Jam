using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Anim_Flipper : MonoBehaviour
{
    bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if ((horizontalInput > 0 || verticalInput > 0) && !facingRight)
    //     {
    //         Flip();
    //     }
    //     else if ((horizontalInput < 0 || verticalInput < 0) && facingRight)
    //     {
    //         Flip();
    //     }
    // }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
