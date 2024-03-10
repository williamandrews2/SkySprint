using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    [SerializeField] public float sensitivity = 3f;
    [SerializeField] float orbitDampening = 10f;

    Vector3 rotation;
    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y -= Input.GetAxis("Mouse Y") * sensitivity;

        rotation.y = Mathf.Clamp(rotation.y, -89.9f, 89.9f);

        //transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);

        Quaternion QT = Quaternion.Euler(rotation.y, rotation.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDampening);
    }
}
