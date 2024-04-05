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
    SpriteRenderer sr;

    protected bool isSelected;
    Color selectedColor;
    public Color unSelectedColor;

    protected string cropName = "Crop";
    float cropAge;

    public List<Sprite> cropPhases;
    int cropStage;

    float startNightVal;

    public static bool watering = false;
    public static bool watered = false;

    protected virtual void Start()
    {
        cropNameUI = GetComponentInChildren<TextMeshProUGUI>();
        wateredIndicator = GetComponentInChildren<Image>();
        sr = GetComponent<SpriteRenderer>();
        cropStage = 0;
        sr.sprite = cropPhases[cropStage];
        selectedColor = sr.color;
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

        if (!isSelected)
        {
            sr.color = unSelectedColor;
        } else sr.color = selectedColor;
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
