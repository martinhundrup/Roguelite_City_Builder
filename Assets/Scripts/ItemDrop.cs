using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // -- ATRIBUTES -- //

    /// <summary>
    /// The transform of the game object the camera will target.
    /// </summary>
    [SerializeField] private Vector3 target;

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
    /// Whether or not the item is currently targeting the player.
    /// </summary>
    private bool targetsPlayer = false;

    /// <summary>
    /// Whether or not the item as arrived at its target position.
    /// </summary>
    private bool hasArrived = false;

    // -- PROPERTIES -- //

    /// <summary>
    /// Gets or sets the transform of the game object the camera will target.
    /// </summary>
    public Vector3 Target
    {
        get { return target; }
        set { target = value; }
    }

    /// <summary>
    /// Gets or sets the damping value to follow the target with. Smaller values result in closer following.
    /// </summary>
    public float Smoothness
    {
        get { return smoothness; }
        set { smoothness = value; }
    }

    // -- UNITY CALLBACKS -- //

    /// <summary>
    /// Called once a frame. Varies with framerate.
    /// </summary>
    private void Update()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, target)) > 0.2f) // only moves the object if it's not at the target already
        {
            UpdatePosition();
        }
        else // makes sure it stops moving when it arrived at initial target location.
        {
            hasArrived = true;

            // destroys this object when it arrives at the player.
            if (targetsPlayer)
            {
                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Called when another object is in a 2D trigger collider.
    /// </summary>
    /// <param name="collision">Contains information about the collision.</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        // the player is in our trigger collider
        if (hasArrived && collision.CompareTag("Player"))
        {
            target = collision.gameObject.transform.position;
            targetsPlayer = true;
        }
    }

    // -- METHODS -- // 

    /// <summary>
    /// Updates the items position towards the target.
    /// </summary>
    private void UpdatePosition()
    {
        // apply any offset
        Vector2 targetPos = target + offset;

        // smooth the position to a new variable
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPos, ref zeroVector, smoothness);

        // set our position to the smoothed position
        transform.position = smoothedPosition;
    }
}
