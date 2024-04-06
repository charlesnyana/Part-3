using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class ControllerNF : MonoBehaviour
{
    // Variables for thirst
    public Slider thirstBar;
    public static float thirstVal; //referred to in text UI and tracks current thirst
    public GameObject warning;

    // Variables on Night Tracking
    public TextMeshProUGUI nightTrack;
    public static float nightVal { get; private set; }

    // Variable to track active crops
    public List<Crop> cropList;
    public TMP_Dropdown cropSelect;

    public Button WaterPlant;

    public GameObject ScreenFader;
    SpriteRenderer FaderSR;
    public Color clear;
    public Color full;
    public AnimationCurve fadeCurve;
    void Start()
    {
        FaderSR = ScreenFader.GetComponent<SpriteRenderer>();
        nightVal = 1;
        thirstVal = 50;
        nightTrack.text = "Night: " + nightVal;
    }

 

    // Update is called once per frame
    void Update()
    {
        thirstBar.value = thirstVal;

        //No need to implement loss condition (when thirst < 0) but i want to imply danger when thirst is low
        if (thirstVal <= 30)
        {
            warning.SetActive(true);
        } else warning.SetActive(false); 

        if (activeCrop == null)
        {
            WaterPlant.interactable = false;
        } else
        {
            WaterPlant.interactable = true;
        }
    }
    public static Crop activeCrop { get; private set; }
    public static void setActiveCrop(Crop crop)
    {
        if (activeCrop != null)
        {
            activeCrop.Active(false);
        }
        activeCrop = crop;
        activeCrop.Active(true);
        Debug.Log("Active crop is " +  activeCrop);
    }

    //this function runs when called by the Sate Thirst button
    public static void fillThirst (float value)
    {
        thirstVal += value;
        thirstVal = Mathf.Clamp(thirstVal, 0, 100);
        Debug.Log("Thirst val updated to: " + thirstVal);
    }

    //this function runs when Next Night button is called to decrease thirstVal and will be called by Bloodroot plant later
    public static void Thirstier(float value)
    {
        thirstVal -= value;
        thirstVal =  Mathf.Clamp(thirstVal, 0, 100);
        Debug.Log("Thirst val updated to: " + thirstVal);
    }

    //This function moves the night value forward which is referenced by the crops later
    public void passNight()
    {
        StartCoroutine(nightFade()); 
    }

    IEnumerator nightFade()
    {
        FaderSR.color = clear;

        ScreenFader.SetActive(true);
        while (FaderSR.color != full)
        {
            float interpolation = 12*fadeCurve.Evaluate(2);
            FaderSR.color = Color.Lerp(FaderSR.color, full, interpolation *Time.deltaTime);         
            yield return null;
        }
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(endNight());

        while (FaderSR.color != clear)
        {
            float interpolation = 12*fadeCurve.Evaluate(2);
            FaderSR.color = Color.Lerp(FaderSR.color, clear, interpolation * Time.deltaTime);
            yield return null;
        }
        ScreenFader.SetActive(false);
        
    }
    IEnumerator endNight()
    {
        nightVal++;
        nightTrack.text = "Night: " + nightVal; //prints new night value
        Thirstier(20);

        foreach (Crop crop in cropList)
        {
            crop.newNight();
        }
        activeCrop = null;
        yield return null;
    }

    public void waterCropBtn()
    {
        Crop.watering = true;
    }

    public void OnDropdownChanged(int index)
    {
        setActiveCrop(this.cropList[index]);
    }
}
