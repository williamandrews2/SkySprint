using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 3f;
    public float orbitDamping = 10f;
    [Range(1f, 100000f)]
    public float distance = 3f; // Distance from player
    public float height = -6f; // Height above player
    public float minVerticalAngle = -89.9f; // Minimum vertical angle
    public float maxVerticalAngle = 89.9f; // Maximum vertical angle

    private Vector3 offset;

    void Start()
    {
        // Calculate the initial offset based on the desired distance and height behind the player
        //offset = -player.forward * distance + Vector3.up * height;
        offset =(transform.position) - (player.position);

        // Ensure that the camera is always at the desired position relative to the player
        if (player != null)
        {           
            UpdateCameraPosition();
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Calculate rotation based on mouse input
        float rotationX = Input.GetAxis("Mouse X") * sensitivity * 1.5f;
        float rotationY = -Input.GetAxis("Mouse Y") * sensitivity;

        // Apply rotation to the offset value
        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0f);
        offset = rotation * offset;

        // Clamp vertical angle
        Vector3 localOffset = player.InverseTransformDirection(offset);
        localOffset = Vector3.RotateTowards(Vector3.forward, localOffset, Mathf.Deg2Rad * (maxVerticalAngle - minVerticalAngle), 0f);
        offset = player.TransformDirection(localOffset);

        // Apply orbit damping ***ISSUE HERE***
        //offset = Vector3.Lerp(offset, offset.normalized * offset.magnitude, Time.deltaTime * orbitDamping);

        // Set camera position
        UpdateCameraPosition();

        // Look at the player
        transform.LookAt(player.position);
    }

    void UpdateCameraPosition()
    {
        // Times 4 factor increases the distance between camera and player.
        Vector3 targetPosition = player.position + offset * 4;     
        transform.position = targetPosition;
    }
}
