using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    // -- EVENTS -- //

    /// <summary>
    /// An event called when a hurtbox takes damage (collides with a hitbox).
    /// </summary>
    /// <param name="damage">The amount of damage delt to this object.</param>
    public delegate void HurtAction(int damage);

    /// <summary>
    /// The event called when this object collides with a hitbox.
    /// </summary>
    public event HurtAction OnHurt;

    // -- METHODS -- //

    /// <summary>
    /// The method called when another object with a 2D collider overlaps with this object's collider.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("i've been hit");

        // a hitbox has collided with this
        if (collision.gameObject.GetComponent<Hitbox>() != null)
        {
            OnHurt(collision.gameObject.GetComponent<Hitbox>().Damage);
        }
    }

    /// <summary>
    /// The method called when another object with a 2D collider overlaps with this object's collider.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // a hitbox has collided with this
        if (collision.gameObject.GetComponent<Hitbox>() != null)
        {
            OnHurt(collision.gameObject.GetComponent<Hitbox>().Damage);
        }
    }
}
