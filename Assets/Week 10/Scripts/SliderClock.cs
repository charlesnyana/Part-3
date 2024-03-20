using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderClock : MonoBehaviour
{
    public Slider slider;
    float timer;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;
        timer = timer % 60;
        slider.value = timer;
    }
}
