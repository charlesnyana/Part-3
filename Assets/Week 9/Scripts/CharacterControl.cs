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

    public Slider sizeSlider;
    public Vector2 baseScale;

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
    
    public void OnDropdownChanged(int index)
    {
        Debug.Log(selector.options[index].text);
        SetSelectedVillager(this.villagerList[index]);
    }

    public void OnValueChanged(Single value)
    {
        if (villagerList != null)
        {
            SelectedVillager.transform.localScale = baseScale * value;
            Debug.Log(SelectedVillager + " is scaled down to: " + sizeSlider.value);
        }
        
    }
}
