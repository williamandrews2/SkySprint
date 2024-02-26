using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movement = 3;
    public float jump = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jump, 0);
        }

        // Move forward
        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, movement);
        }

        // Move right
        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(movement, 0, 0);
        }

        // Move left
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(movement*(-1), 0, 0);
        }

        // Move backward
        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, movement*(-1));
        }
    }
}
