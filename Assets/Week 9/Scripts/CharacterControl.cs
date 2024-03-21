using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public GameObject textUI;
    static TextMeshProUGUI typeText;

    public TMP_Dropdown selector;
    public List<Villager> villagerList;

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
    
    public void OnValueChanged(int index)
    {
        Debug.Log(selector.options[index].text);
        SetSelectedVillager(this.villagerList[index]);
    }
}
