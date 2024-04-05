using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    void Start()
    {
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
        nightVal++;
        nightTrack.text = "Night: " + nightVal; //prints new night value
    }
}
