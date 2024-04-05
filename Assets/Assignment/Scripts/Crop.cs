using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Crop : MonoBehaviour
{
    TextMeshProUGUI cropName;
    Image wateredIndicator;

    private void Start()
    {
        cropName = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(cropName.text);
        wateredIndicator = GetComponentInChildren<Image>();
        wateredIndicator.enabled = false;
    }
}
