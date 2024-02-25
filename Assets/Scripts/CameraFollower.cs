using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolllower : MonoBehaviour
{
    /// <summary>
    /// The transform of the game object the camera will target.
    /// </summary>
    [SerializeField] private Transform target;

    /// <summary>
    /// The offset at which we look at the target.
    /// </summary>
    [SerializeField] private Vector3 offset;

    /// <summary>
    /// The damping value to follow the target with. Smaller values result in closer following.
    /// </summary>
    [SerializeField] private float smoothness;

    /// <summary>
    /// The 3D zero vector as a variable.
    /// </summary>
    private Vector3 zeroVector = Vector3.zero;

    /// <summary>
    /// The final position to which the camera moves after the offset.
    /// </summary>
    private Vector3 targetPos;

    /// <summary>
    /// Called once a frame. Varies with framerate.
    /// </summary>
    private void Update()
    {
        if (transform.position != target.position) // only moves the object if it's not at the target already
        {
            UpdatePosition();
        }
    }

    /// <summary>
    /// Updates the camera's position towards the target.
    /// </summary>
    private void UpdatePosition()
    {
        // apply any offset
        targetPos = target.position + offset;

        // smooth the position to a new variable
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPos, ref zeroVector, smoothness);

        // set our position to the smoothed position
        transform.position = smoothedPosition;
    }


}
