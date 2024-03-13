using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject textUI;
    static TextMeshProUGUI typeText;
    static string villagerType;

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
        if (villager.ToString() == "Merchant (Merchant)") villagerType = "Merchant";
        if (villager.ToString() == "Archer (Archer)") villagerType = "Archer";
        if (villager.ToString() == "Thief (Thief)") villagerType = "Thief";
        typeText.text = villagerType;
    }
    
}
