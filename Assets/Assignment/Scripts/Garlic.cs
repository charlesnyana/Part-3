using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garlic : Crop
{
    protected override void Start()
    {
        cropName = "Garlic";
        base.Start();
    }
    protected override IEnumerator waterCrop()
    {
        ControllerNF.fillThirst(-5);
        return base.waterCrop();
    }
}
