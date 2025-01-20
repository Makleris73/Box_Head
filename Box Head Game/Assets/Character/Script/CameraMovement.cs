using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // The player's transform
    public Vector3 offset; // Offset from the player
    public Vector2 minBoundary; // Minimum x and z values
    public Vector2 maxBoundary; // Maximum x and z values

    void Start()
    {
        // Set an initial offset if not set in the inspector
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Calculate the desired position with the offset
        Vector3 desiredPosition = player.position + offset;

        // Clamp the position to stay within the boundaries
        float clampedX = Mathf.Clamp(desiredPosition.x, minBoundary.x, maxBoundary.x);
        float clampedZ = Mathf.Clamp(desiredPosition.z, minBoundary.y, maxBoundary.y);

        // Update the camera position with the clamped values
        transform.position = new Vector3(clampedX, desiredPosition.y, clampedZ);
    }
}
