using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Village : MonoBehaviour
{

    [SerializeField] float hourTime;
    [SerializeField] float countDown;

    // references to the UI resource read outs
    [SerializeField] TextMeshProUGUI[] resourceTexts;

    // the dimensions of the interior of the village
    Vector2 dimensions;

    // an array of every building in the village
    Building[] buildings;

    // the total resources stored in the city
    // key: [food, water, gold, wood, rock, metal]
    [SerializeField] int[] resourceStorage = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        // find every building in the scene
        buildings = FindObjectsOfType<Building>();
    }


    // called by the game manager once per in-game hours
    // collects and redistributes resources to buildings that need it to function
    public void HourlyCheckup()
    {
        // first add any production to the resource storage
        foreach (Building b in buildings)
        {
            for (int i = 0; i < 6; i++)
            {
                if (b.Running) // only receive from active buildings
                    resourceStorage[i] += b.GetProduction()[i];
            }
        }

        // now pay the cost for each building
        // if we run out of any the resources for any of the buildings, we shut that one down
        foreach (Building b in buildings)
        {
            bool canPay = true;

            int[] temp = new int[6];
            for (int i = 0; i < 6; i++) // we do first temp runthrough to make sure we'd have enough to pay for that building
            {
                temp[i] = resourceStorage[i] - b.GetCosts()[i];

                if (temp[i] < 0) // we overshot our storage, so we can stop checking for this building
                {
                    canPay = false; // make sure we don't deduct any resources
                    b.Running = false; // shut down the building
                    break;
                }
            }

            // if we can pay, then we will deduct from our resources
            for (int i = 0; i < 6 && canPay; i++)
            {
                resourceStorage[i] = temp[i];
                b.Running = true; // turn the building back on
            }
        }

        // update the UI
        UpdateUIText();
    }

    // updates the UI text
    void UpdateUIText()
    {
        resourceTexts[0].text = "food: " + resourceStorage[0];
        resourceTexts[1].text = "water: " + resourceStorage[1];
        resourceTexts[2].text = "gold: " + resourceStorage[2];
        resourceTexts[3].text = "wood: " + resourceStorage[3];
        resourceTexts[4].text = "stone: " + resourceStorage[4];
        resourceTexts[5].text = "metal: " + resourceStorage[5];
    }

    // Update is called once per frame
    void Update()
    {
        countDown += 1 * Time.deltaTime;
        if (countDown >= hourTime)
        {
            HourlyCheckup();
            countDown = 0;
        }
        
    }
}
