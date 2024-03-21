using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Building : MonoBehaviour
{
    Vector2 startScale;
    Vector2 endScale;
    public float timer;
    float speed = 0;
    public AnimationCurve curve;
    float sFactor;

    public List <GameObject> buildings;
    GameObject currentBuilding;
    bool constructing;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sequenceOrder());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed += Time.deltaTime / timer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buildings[3].SetActive(false);
            StartCoroutine(sequenceOrder());
        }
    }
    IEnumerator sequenceOrder()
    {
        //yield return new WaitForSeconds(1);
        yield return StartCoroutine(building(0));
        yield return StartCoroutine(building(1));
        buildings[0].SetActive(false);
        yield return StartCoroutine(building(2));
        buildings[1].SetActive(false);
        yield return StartCoroutine(building(3));
        buildings[2].SetActive(false);
    }

    IEnumerator building(int index)
    {
        currentBuilding = buildings[index];
        
        endScale = currentBuilding.transform.localScale;
        startScale = Vector3.zero;
        currentBuilding.transform.localScale = startScale;
        currentBuilding.SetActive(true);

        constructing = true;

        while (constructing)
        {
            sFactor += curve.Evaluate(speed);
            currentBuilding.transform.localScale = Vector2.Lerp(startScale, endScale, sFactor);

            if (currentBuilding.transform.localScale.x >= endScale.x) constructing = false; 
            yield return null;
        }

        sFactor = 0f;
        speed = 0f;
        Debug.Log("done building stage: " + index);
    }

}
