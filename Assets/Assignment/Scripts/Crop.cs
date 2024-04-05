using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Crop : MonoBehaviour
{
    TextMeshProUGUI cropName;
    Image wateredIndicator;

    protected bool isSelected;

    protected private void Start()
    {
        cropName = GetComponentInChildren<TextMeshProUGUI>();
        wateredIndicator = GetComponentInChildren<Image>();
        wateredIndicator.enabled = false;
        Active(false);
    }

    public void Active(bool value)
    {
        isSelected = value;
    }
}
