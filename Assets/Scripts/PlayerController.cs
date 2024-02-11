using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody; // holds the reference to the player's Rigidbody2D component
    SpriteRenderer spriteRenderer; // holds the reference to the player's Sprite Renderer component
    Animator animator; // holds the reference to the player's Animator component


    [SerializeField] float movementSpeed; // the value to multiply the movement vector by; the speed of the play



    /// <summary>
    /// Called once at beginning of scene.
    /// </summary>
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Called once a frame.
    /// </summary>
    private void Update()
    {
        Movement();
    }


    /// <summary>
    /// Handles movement related input and rigidbody forces responsible for movement
    /// </summary>
    private void Movement()
    {

        // find the horizontal movement vector
        float x = Input.GetAxis("Horizontal");

        // find the vertical movement vector
        float y = Input.GetAxis("Vertical");

        // update animation state to running if moving in either direction
        if (Mathf.Abs(x) != 0 || Mathf.Abs(y) != 0)
        {
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
        }

        // adjust the flipX attribute of the sprite appropriately
        // we don't use an else so the player won't flip back to default when negative movement stops
        if (x < 0)
            spriteRenderer.flipX = true;
        else if (x > 0)
            spriteRenderer.flipX = false;        

        // create the input based movement vector; this will be normalized to achieve the final movement vector
        Vector2 movement_vector = new Vector2(x, y);
        movement_vector.Normalize(); // this normalizes (makes the magnitude 1)

        // set the rigidbody velocity to the movement vector
        rigidBody.velocity = movement_vector * movementSpeed;
    }
}
