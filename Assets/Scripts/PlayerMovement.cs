using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jump = 5f;
    // small sphere located on the bottom of the player
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }

    bool isGrounded()
    {
        // Arguments are position of sphere, size of sphere, and layer mask.
        // Returns a bool
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    /* Explanation of the script:
     * We first create changeable fields for movement speed and jump force of the player.
     * Next, we create a reference to the rigidbody in the start function since all the 
     * physics is contained in the rigidbody component, and we can add the force here to 
     * move it in a certain direction. Next we check if the player is on the ground and
     * upon pressing space the player moves with jump force of "jump", and continues moving
     * in the X and Z directions if it was already moving. 
     * 
     * The isGrounded function uses a small sphere pinned to the bottom of the player to 
     * check if it overlaps with the "ground" layer we created for the floor prefab.
     */
}
