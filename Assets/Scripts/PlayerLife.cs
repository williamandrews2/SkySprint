using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    GameObject objectToDisappear; 

    private void Start()
    {
        objectToDisappear = GameObject.FindWithTag("Player");
    }

    [SerializeField] AudioSource deathSound;
    private void Update()
    {
        if(transform.position.y< -2f && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        dead = true;
        objectToDisappear.SetActive(false);
        // Reloads the level after 1.3 seconds.
        Invoke(nameof(ReloadLevel), 1.3f);
        deathSound.Play();
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
