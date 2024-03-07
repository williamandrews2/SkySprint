using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlank : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 rotationDirection = new Vector3();
    void Update()
    {
        transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // ???
        }
    }
}
