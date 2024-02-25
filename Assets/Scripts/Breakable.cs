using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    // -- ATRIBUTES -- //

    /// <summary>
    /// The current amount of damage this object can take before it is destroyed.
    /// </summary>
    [SerializeField] private int health;

    /// <summary>
    /// Holds reference to the hurtbox of this object.
    /// </summary>
    private Hurtbox hurtbox;

    // -- PROPERTIES -- //

    /// <summary>
    /// Gets the amount of damage this object can take before it is destroyed.
    /// </summary>
    public int Health
    {
        get { return health; }
    }

    // -- UNITY CALLBACKS -- //

    /// <summary>
    /// Called once at beginning of scene.
    /// </summary>
    private void Start()
    {
        hurtbox = GetComponent<Hurtbox>();
        hurtbox.OnHurt += Hurt;
    }

    // -- METHODS -- //

    /// <summary>
    /// Destroys this game object if health is at or below 0.
    /// </summary>
    private void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// The method called when the hurtbox is hit.
    /// </summary>
    /// <param name="damage">The amount of damage the hurtbox was dealt.</param>
    private void Hurt(int damage)
    {
        health -= damage;
        CheckHealth();
    }
}
