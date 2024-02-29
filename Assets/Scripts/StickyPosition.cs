using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPosition : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            // Make the Player a child of this platform (transform)
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Make the Player a child of this platform (transform)
            collision.gameObject.transform.SetParent(null);
        }
    }

}

/* Explanation of the script:
 * - We need to change the player to become a child of the moving platform but only
 * while we are standing on the moving platform.
 * 
 * 
 */
