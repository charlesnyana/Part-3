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
    public Color wiltedColor;

    protected string cropName = "Crop";
    float cropAge;
    protected int maxStage = 4;

    public List<Sprite> cropPhases;
    int cropStage;
    public Sprite wiltedStage;
    bool wilted = false;

    float startNightVal;

    public static bool watering = false;
    public static bool watered = false;

    protected virtual void Start()
    {
        //Sets up references
        cropNameUI = GetComponentInChildren<TextMeshProUGUI>();
        wateredIndicator = GetComponentInChildren<Image>();
        sr = GetComponent<SpriteRenderer>();
        
        //Establishes starting point for growth
        cropStage = 0;
        sr.sprite = cropPhases[cropStage];
        selectedColor = sr.color; //Takes reference for what sprite is supposed to look when selected.
        wateredIndicator.enabled = false; //turns off watered indicator.
        Active(false); //so it doesn't spawn as selected.

        cropNameUI.text = cropName;
        startNightVal = ControllerNF.nightVal; // sets the Night value of the crop's instantiation
    }

    protected virtual void Update()
    {
        cropAge = ControllerNF.nightVal - startNightVal; // calculates how long the crop has been around

        if (watering && isSelected) //water crop button retuns watering = true, this watches for the change in Controller
        {
            StartCoroutine(waterCrop());
            watering = false;
        }

        if (!isSelected) // visual signifier for crops
        {
            sr.color = unSelectedColor;
        } else sr.color = selectedColor;
    }

    IEnumerator growingConditions()
    {
        if (wilted == false) StartCoroutine (growth());
        yield return new WaitForSeconds(1);
        Debug.Log(cropName + " is ready for next night.");          
    }

    protected virtual 
        IEnumerator growth()
        {
        Debug.Log(cropName + " conditions: watered-" + watered + " cropStage-"+cropStage+ " wilted-"+wilted);
            if (wateredIndicator.enabled == true && cropStage <= maxStage && wilted == false)
            {
                cropStage++;
                sr.sprite = cropPhases[cropStage];
            } else
                {
                    StartCoroutine(wilting());
                }
            yield return null;
        }
    IEnumerator wilting()
    {
        sr.sprite = wiltedStage;
        sr.color = wiltedColor;
        wilted = true;
        cropName = "Wilted";
        cropNameUI.text = cropName;
        Debug.Log(cropName + " has wilted. It has lived: "+cropAge+" days");

        yield return null;
    }

    public void newNight() //reset logic per night
    {
        //Growth Coroutine
        StartCoroutine(growingConditions());
        isSelected = false;
        watered = false;
        wateredIndicator.enabled = false;
        cropAge++;
        Active(false);
    }

    IEnumerator waterCrop() //coroutine to water crop. 
    {
        watered = true;
        wateredIndicator.enabled = true;
        Debug.Log(cropName+": is watered");
        yield return null;
    }

    public void Active(bool value) //identify in script if this object is selected.
    {
        isSelected = value;
    }
}
