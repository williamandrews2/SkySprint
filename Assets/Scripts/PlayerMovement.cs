using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // letter f signifies a float
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jump = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed); ;

        // We are using rb.velocity.x and rb.velocity.y insted of 0.

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
}
