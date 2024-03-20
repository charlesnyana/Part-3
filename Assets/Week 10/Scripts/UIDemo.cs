using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{
    public SpriteRenderer sr;
    public TMP_Dropdown dropdown;
    public Color start;
    public Color end;
    float interpolation;
    // Start is called before the first frame update
    public void SliderValueHasChanged(Single value)
    {
        interpolation = value;
    }

    public void Update()
    {
        sr.color = Color.Lerp(start, end, interpolation/60);
    }

    public void DropdownHasChanged(int index)
    {
        Debug.Log(dropdown.options[index].text);
;    }
}
