using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    public Vector3 offset;

    private bool followPlayer = true; // Add a boolean flag to control camera following

    // Update is called once per frame
    void LateUpdate()
    {
        if (followPlayer && target != null)
        {
            // Use SmoothDamp to smoothly follow the player
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, target.position.z) + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 3);
        }
    }

    // Method to toggle camera following on/off
    public void ToggleFollowPlayer(bool follow)
    {
        followPlayer = follow;
    }
}
