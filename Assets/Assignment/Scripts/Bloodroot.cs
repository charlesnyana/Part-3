using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodroot : Crop
{
    public float maxNoWater = 2;
    bool noWaterDay = false;
    bool growthAllowed = false;


    protected override void Start()
    {
        cropName = "Bloodroot";
        base.Start();
    }
    protected override IEnumerator Growth()
    {
        if (wateredIndicator.enabled == true && noWaterDay == true) //if watered and watered before, run this function to wilt the plant (it is noWaterDay)
        {
            Debug.Log("overwatered Bloodroot");
            StartCoroutine(Wilting());
            noWaterDay = false;
        }

        else if (wateredIndicator.enabled == true && noWaterDay == false) //if watered and not watered night before, make the next night a no Water day
        {
            Debug.Log("watered once. hold watering next night");
            noWaterDay = true;
        }

        else if (wateredIndicator.enabled == false && noWaterDay == false) // if not watered on this night and not watered before, it wilts from not being watered 2 days in a row.
        {
            Debug.Log("wilted from neglect.");
            StartCoroutine(Wilting());

        }

        else if (wateredIndicator.enabled == false && noWaterDay == true) //if not watered tonight but watered the night before, it's cleared to grow to next phase
        {
            growthAllowed = true;
        }

        if (growthAllowed && cropStage <= maxStage && wilted == false)
        {
            cropStage++;
            sr.sprite = cropPhases[cropStage];

            noWaterDay = false;
            growthAllowed = false;
        }
        yield return null;
    }
}

