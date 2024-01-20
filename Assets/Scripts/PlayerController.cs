using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody; // holds the references to the player's Rigidbody2D component
    SpriteRenderer spriteRenderer; // holds the references to the player's Sprite Renderer component



    [SerializeField] float movementSpeed; // the value to multiply the movement vector by; the speed of the play



    // called once at beginning of scene
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // called once a frame
    private void Update()
    {
        Movement();
    }


    // handles movement related input and rigidbody forces responsible for movement
    private void Movement()
    {

        // find the horizontal movement vector
        float x = Input.GetAxis("Horizontal");

        // adjust the flipX attribute of the sprite appropriately
        // we don't use an else so the player won't flip back to default when negative movement stops
        if (x < 0)
            spriteRenderer.flipX = true;
        else if (x > 0)
            spriteRenderer.flipX = false;

        // find the vertical movement vector
        float y = Input.GetAxis("Vertical");

        // create the input based movement vector; this will be normalized to achieve the final movement vector
        Vector2 movement_vector = new Vector2(x, y);
        movement_vector.Normalize(); // this normalizes (makes the magnitude 1)

        // set the rigidbody velocity to the movement vector
        rigidBody.velocity = movement_vector * movementSpeed;
    }
}
