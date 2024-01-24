using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // the dimensions of the building
    Vector2 dimensions;

    // the next upgrade of the building -PLACEHOLDER UNTIL A PROPER SYSTEM IS SET UP-
    [SerializeField] Building upgrade;

    // whether or not the building is currently running
    [SerializeField] bool running = true;

    // the amount of workers needed to keep the building operational
    [SerializeField] int workers = 1;

    public bool Running // running property
    {
        get { return running; }
        set { running = value; }
    }

    // key for the following arrays: [food, water, gold, wood, rock, metal]
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
