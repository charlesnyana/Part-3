using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject textUI;
    static TextMeshProUGUI typeText;

    private void Start()
    {
        typeText = textUI.GetComponent<TextMeshProUGUI>();
    }

    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
            typeText.text = "Select a Villager";
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
 
        typeText.text = villager.GetType().ToString(); //added Kit's reccommendation from in-class assessment
    }
    
}
