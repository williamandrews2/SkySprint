using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            Debug.Log("DEAD");
        }
    }
}

/* Explanation of script:
 * 
 */
