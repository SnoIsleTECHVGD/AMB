using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float smoothSpeed = 10f; // Adjust the smooth speed as needed
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -5f); // Adjust the offset as needed

    void FixedUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.fixedDeltaTime * smoothSpeed);
        transform.position = smoothedPosition;

        // Set the camera rotation to look at the player
        transform.LookAt(target.position);
    }
}