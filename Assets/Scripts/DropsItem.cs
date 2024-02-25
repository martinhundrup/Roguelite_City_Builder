using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsItem : MonoBehaviour
{
    // -- ATRIBUTES -- //

    /// <summary>
    /// Holds reference to all the items to be dropped when this object is destroyed.
    /// </summary>
    [SerializeField] private ItemDrop[] itemDrops;

    /// <summary>
    /// The amount of each item to drop.
    /// </summary>
    [SerializeField] private int[] itemDropAmounts;

    /// <summary>
    /// The size of the area items are dropped in.
    /// </summary>
    [SerializeField] private float dropArea;

    // -- PROPERTIES -- //

    /// <summary>
    /// Gets the array containing the items to be dropped when this object is destroyed.
    /// </summary>
    public ItemDrop[] ItemDrops
    {
        get { return itemDrops; }
    }

    /// <summary>
    /// Gets the amount of each item to drop.
    /// </summary>
    public int[] ItemDropAmounts
    {
        get { return itemDropAmounts; }
    }

    /// <summary>
    /// Gets or sets the size of the area the items are dropped in.
    /// </summary>
    public float DropArea
    {
        get { return dropArea; }
        set { dropArea = value; }
    }

    // -- UNITY CALLBACKS -- //

    /// <summary>
    /// Essentially the destructor for this script.
    /// </summary>
    private void OnDestroy()
    {
        for (int i = 0; i < itemDrops.Length; i++) // loop for each item to be dropped
        {
            for (int j = 0; j < itemDropAmounts[i]; j++) // loop for the amount of each item
            {
                // generate a random position in the drop area
                Vector2 pos = transform.position;
                pos.x += dropArea * Random.value - dropArea / 2; // Random.value returns a number between 0 and 1 inclusive
                pos.y += dropArea * Random.value - dropArea / 2;

                // instantiate the drop and place it in the random area
                ItemDrop item = Instantiate(itemDrops[i]);
                item.transform.position = transform.position;
                item.Target = pos;
            }
        }
    }
}
