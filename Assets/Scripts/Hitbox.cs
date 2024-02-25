using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    /// <summary>
    /// The damage this object deals.
    /// </summary>
    [SerializeField] private int damage;

    /// <summary>
    /// Gets or sets the damage this object deals.
    /// </summary>
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
}
