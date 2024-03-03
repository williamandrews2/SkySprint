using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y< -5)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        // Reloads the level after 1.3 seconds.
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

/* Explanation of script:
 * 
 * "Die" disables the mesh renderer, changes rigidbody properties
 * to "is kinematic", and disables Player Movement script.
 */
