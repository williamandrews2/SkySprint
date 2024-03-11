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
            collision.gameObject.transform.SetParent(transform, true);
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
