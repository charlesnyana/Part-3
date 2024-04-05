using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class Crop : MonoBehaviour
{
    TextMeshProUGUI cropNameUI;
    Image wateredIndicator;

    protected bool isSelected;

    protected string cropName = "Crop";
    float cropAge;

    float startNightVal;

    public static bool watering = false;
    public static bool watered = false;

    protected virtual void Start()
    {
        cropNameUI = GetComponentInChildren<TextMeshProUGUI>();
        wateredIndicator = GetComponentInChildren<Image>();
        wateredIndicator.enabled = false;
        Active(false);

        cropNameUI.text = cropName;
        startNightVal = ControllerNF.nightVal; // sets the Night value of the crop's instantiation
    }

    protected virtual void Update()
    {
        cropAge = ControllerNF.nightVal - startNightVal; // calculates how long the crop has been around

        if (watering && isSelected)
        {
            StartCoroutine(waterCrop());
            watering = false;
        }
    }

    public void newNight()
    {
        isSelected = false;
        watered = false;
        wateredIndicator.enabled = false;
        cropAge++;
        Active(false);
        Debug.Log(cropName + " is ready for next night.");
    }

    IEnumerator waterCrop()
    {
        watered = true;
        wateredIndicator.enabled = true;
        Debug.Log(cropName+": is watered");
        yield return null;
    }

    public void Active(bool value)
    {
        isSelected = value;
    }
}
