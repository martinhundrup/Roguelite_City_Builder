using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    // -- FIELDS -- //

    /// <summary>
    /// The name of the item.
    /// </summary>
    [SerializeField] private string itemName;

    /// <summary>
    /// The sprite representation for the item.
    /// </summary>
    [SerializeField] private Sprite icon;

    /// <summary>
    /// A short desciption for defining the item.
    /// </summary>
    [TextArea]
    [SerializeField] private string description;

    // -- PROPERTIES -- //

    /// <summary>
    /// Gets the name of the item.
    /// </summary>
    public string ItemName
    {
        get { return itemName; }
    }

    /// <summary>
    /// Gets the sprite representation for this item.
    /// </summary>
    public Sprite Icon
    {
        get { return icon; }
    }

    /// <summary>
    /// Gets the description for the object.
    /// </summary>
    public string Description
    {
        get { return description; }
    }
}
