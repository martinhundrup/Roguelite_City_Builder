using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Represents the four cardinal directions.
    /// </summary>
    public enum Direction
    {
        Up, Down, Left, Right
    }

    #region COMPONENTS

    // -- COMPONENTS -- //

    /// <summary>
    /// Holds the reference to the player's Rigidbody2D component.
    /// </summary>
    private Rigidbody2D rigidBody;

    /// <summary>
    /// Holds the reference to the player's Sprite Renderer component.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Holds the reference to the player's Animator component
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Holds reference to the player's top attack hitbox.
    /// </summary>
    [SerializeField] private GameObject topHitbox;

    /// <summary>
    /// Holds reference to the player's bottom attack hitbox.
    /// </summary>
    [SerializeField] private GameObject bottomHitbox;

    /// <summary>
    /// Holds reference to the player's left attack hitbox.
    /// </summary>
    [SerializeField] private GameObject leftHitbox;

    /// <summary>
    /// Holds reference to the player's right attack hitbox.
    /// </summary>
    [SerializeField] private GameObject rightHitbox;

    #endregion

    #region ATTRIBUTES

    // -- STATS -- //

    /// <summary>
    /// The value to multiply the movement vector by; the speed of the player.
    /// </summary>
    [SerializeField] private float movementSpeed;

    /// <summary>
    /// The time to wait in between attacks.
    /// </summary>
    [SerializeField] private float attackCooldown = 0f;

    /// <summary>
    /// The time the attack hitbox is active.
    /// </summary>
    [SerializeField] private float attackDuration = 0f;

    // -- STATES -- //

    /// <summary>
    /// The time elapsed since the last attack.
    /// </summary>
    private float attackCooldownProgress;

    /// <summary>
    /// The current direction the player is facing.
    /// </summary>
    [SerializeField] private Direction facing;

    /// <summary>
    /// Whether or not the player is actively attacking or not.
    /// </summary>
    private bool isAttacking;

    #endregion

    #region PROPERTIES

    // -- PROPERTIES -- //

    /// <summary>
    /// Gets the movement speed of the player.
    /// </summary>
    public float MovementSpeed
    {
        get { return movementSpeed; }
    }

    /// <summary>
    /// Gets the time to wait in between attacks.
    /// </summary>
    public float AttackCooldown
    {
        get { return attackCooldown; }
    }

    /// <summary>
    /// Gets the time elapsed since the last attack.
    /// </summary>
    public float AttackCooldownProgress
    {
        get { return attackCooldownProgress; }
    }

    /// <summary>
    /// Gets the current direction the player is facing.
    /// </summary>
    public Direction Facing
    {
        get { return facing; }
    }

    #endregion

    #region UNITY CALLBACKS

    /// <summary>
    /// Called once at beginning of scene.
    /// </summary>
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();

        DeactivateAllHitboxes();
    }

    /// <summary>
    /// Called once a frame. Varies with framerate.
    /// </summary>
    private void Update()
    {
        Movement();
        UpdateFacing();
   
        Attack();
    }

    #endregion

    #region METHODS

    /// <summary>
    /// Handles movement related input and rigidbody forces responsible for movement
    /// </summary>
    private void Movement()
    {
        
        // find the horizontal movement vector
        float x = Input.GetAxis("Horizontal");

        // find the vertical movement vector
        float y = Input.GetAxis("Vertical");

        if (isAttacking) // halts movement when attacking
        {
            x = y = 0f;
        }

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

        // create the input based movement vector; this will be normalized to achieve the final movement vector
        Vector2 movement_vector = new Vector2(x, y);
        movement_vector.Normalize(); // this normalizes (makes the magnitude 1)

        // set the rigidbody velocity to the movement vector
        rigidBody.velocity = movement_vector * movementSpeed;
    }

    /// <summary>
    /// Updates the sprite renderer and facing directions.
    /// </summary>
    private void UpdateFacing()
    {
        // find the horizontal movement vector
        float x = Input.GetAxis("Horizontal");

        // find the vertical movement vector
        float y = Input.GetAxis("Vertical");

        if (isAttacking) // halts movement when attacking
        {
            x = y = 0f;
        }

        // adjust the flipX attribute of the sprite appropriately
        // we don't use an else so the player won't flip back to default when negative movement stops
        if (x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // adjust the facing direction based on the current movement axis
        if (Mathf.Abs(x) < Mathf.Abs(y)) // facing a vertical direction
        {
            if (y > 0)
            {
                facing = Direction.Up;
            }
            else
            {
                facing = Direction.Down;
            }
        }
        else if (Mathf.Abs(x) > Mathf.Abs(y)) // facing a horizontal direction
        {
            if (x > 0)
            {
                facing = Direction.Right;
            }
            else
            {
                facing = Direction.Left;
            }
        }
    }

    /// <summary>
    /// Handles attacking related input and actions.
    /// </summary>
    private void Attack()
    {
        // increment time since last attack
        attackCooldownProgress += Time.deltaTime;

        // user pressed the action button and they have waited enough time to attack
        if (Input.GetButton("Action") && attackCooldownProgress >= attackCooldown)
        {
            // activate hitbox
            StartCoroutine(AttackHitbox());

            // reset time waited since last attack
            attackCooldownProgress = 0f;
        }
    }

    /// <summary>
    /// Activates the proper hitbox based on the current direction the player is facing.
    /// </summary>
    /// <returns>A new yield.</returns>
    private IEnumerator AttackHitbox()
    {
        switch (facing) // activate respective hitbox
        {
            case Direction.Up:
                topHitbox.SetActive(true);
                break;
            case Direction.Down:
                bottomHitbox.SetActive(true);
                break;
            case Direction.Left:
                leftHitbox.SetActive(true);
                break;
            case Direction.Right:
                rightHitbox.SetActive(true);
                break;
        }

        // set is attacking to true
        isAttacking = true;

        // wait for duration of attack
        yield return new WaitForSeconds(attackDuration);

        // set is attacking to false
        isAttacking = false;

        DeactivateAllHitboxes();
    }

    /// <summary>
    /// Disables all attack hitboxes.
    /// </summary>
    private void DeactivateAllHitboxes()
    {
        // deactive all hitboxes
        topHitbox.SetActive(false);
        bottomHitbox.SetActive(false);
        leftHitbox.SetActive(false);
        rightHitbox.SetActive(false);
    }

    #endregion
}
