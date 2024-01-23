using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    // the dimensions of the interior of the village
    Vector2 dimensions;

    // an array of every building in the village
    Building[] buildings;

    // the total resources stored in the city
    int[] resourceStorage = new int[6];

    
    // called by the game manager once per in-game hours
    // collects and redistributes resources to buildings that need it to function
    public void HourlyCheckup()
    {
        // first add any production to the resource storage
        foreach (Building b in buildings)
        {
            for (int i = 0; i < 6; i++)
            {
                resourceStorage[i] += b.GetProduction()[i];
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
