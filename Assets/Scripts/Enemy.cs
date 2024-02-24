using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region STATS

    // -- STATS -- //

    /// <summary>
    /// The maximum health value this enemy cam have.
    /// </summary>
    [SerializeField] private int maxHealth = 0;

    /// <summary>
    /// The current health value the enemy has.
    /// </summary>
    [SerializeField] private int health = 0;

    /// <summary>
    /// The amount of damage attacks by this enemy deal.
    /// </summary>
    [SerializeField] private int damage = 0;

    /// <summary>
    /// The movement speed of this enemy.
    /// </summary>
    [SerializeField] private float speed = 0f;

    #endregion

    #region PROPERTIES

    // -- PROPERTIES -- //

    /// <summary>
    /// Gets the maximum health value this enemy can have.
    /// </summary>
    public int MaxHealth
    {
        get { return maxHealth; }         
    }

    /// <summary>
    /// Gets or sets the current health value the enemy has.
    /// </summary>
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    /// <summary>
    /// Gets or sets the amount of damage attacks by this enemy deal.
    /// </summary>
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    /// <summary>
    /// Gets or sets the movement speed of this enemy.
    /// </summary>
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    #endregion

    #region UNITY CALLBACKS

    /// <summary>
    /// Called once at beginning of scene.
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Called once a frame. Varies with framerate.
    /// </summary>
    void Update()
    {

    }

    #endregion

    #region METHODS

    // -- CONSTRUCTORS -- //

    /// <summary>
    /// Creates a new Enemy object.
    /// </summary>
    /// <param name="nMaxHealth">The maximum and starting health of the enemy.</param>
    /// <param name="nDamage">The damage dealt by this enemy.</param>
    /// <param name="nSpeed">The movement speed of this enemy.</param>
    public Enemy(int nMaxHealth = 0, int nDamage = 0, float nSpeed = 0)
    {
        maxHealth = health = nMaxHealth;
        damage = nDamage;
        speed = nSpeed;
    }

    #endregion
}