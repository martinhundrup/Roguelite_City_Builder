using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // the dimensions of the building
    Vector2 dimensions;

    // whether or not the building is currently running
    [SerializeField] bool running;

    // the building cost for each material
    [SerializeField] int[] buildingCosts = new int[6];

    // the maintenance cost of each material per hour
    [SerializeField] int[] hourlyCosts = new int[6];

    // the production of each material per hour
    [SerializeField] int[] productionRate = new int[6];

    // the storage capacity of each material
    [SerializeField] int[] maxCapacities = new int[6];


    // called by village once an hour to collect any profits of the building
    public int[] GetProduction()
    {
        return productionRate;
    }

    // called by village once an hour to collect any profits of the building
    public int[] GetCosts()
    {
        return hourlyCosts;
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
