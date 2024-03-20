using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    Vector2 startScale;
    Vector2 endScale;
    public float interval;
    public AnimationCurve curve;
    float interpolation;

    public List <GameObject> buildings;
    int currentBuildingIndex = -1;
    GameObject currentBuilding;
    bool constructing;


    // Start is called before the first frame update
    void Start()
    {

        interpolation = curve.Evaluate(interval);
        StartCoroutine(building());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator building()
    {
        currentBuildingIndex++;
        currentBuilding = buildings[currentBuildingIndex];
        endScale = currentBuilding.transform.localScale;
        startScale = Vector2.zero;
        Debug.Log(endScale);

        constructing = true;

        while (constructing)
        {
            interpolation += Time.deltaTime;
            Debug.Log(interpolation);
            currentBuilding.transform.localScale = Vector2.Lerp(startScale, endScale, interpolation);
            if (currentBuilding.transform.localScale.x >= endScale.x) constructing = false; 
            yield return null;
        }

        
        Debug.Log("done building stage: " + currentBuildingIndex + 1);

        yield return new WaitForSeconds(interval);
        currentBuildingIndex++;
        Debug.Log("done building stage: " + (currentBuildingIndex + (int) 1));
    }

}
