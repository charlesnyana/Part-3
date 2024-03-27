using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;
    public TextMeshProUGUI squareTMP;
    public TextMeshProUGUI triangleTMP;
    public TextMeshProUGUI circleTMP;
    public TextMeshProUGUI crTMP;
    public int running;
    Coroutine coroutine;

    void Start()
    {
       StartCoroutine(GrowShapes());
    }

    void Update()
    {
        crTMP.text = "Coroutines running " + running.ToString();
    }
    IEnumerator GrowShapes()
    {
        running++;
        yield return StartCoroutine(Square());
        
        yield return new WaitForSeconds(1f);
        
        yield return StartCoroutine(Triangle());

        
        yield return new WaitForSeconds(1f);
        //coroutine = StartCoroutine(Circle());
        yield return StartCoroutine(Circle());
 
        yield return coroutine;
        running--;
    }
    IEnumerator Square()
    {
        running++;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            square.transform.localScale = scale;
            squareTMP.text = "Square: " + scale;
            yield return null;
        }
        running--;
    }
    IEnumerator Triangle()
    {
        running++;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            triangle.transform.localScale = scale;
            triangleTMP.text = "Triangle: " + scale;
            yield return null;
        }
        running--;
    }
    IEnumerator Circle()
    {
        running++;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            circle.transform.localScale = scale;
            circleTMP.text = "Cirlce: " + scale;
            yield return null;
        }
        while (size > 0)
        {
            size -= Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            circle.transform.localScale = scale;
            circleTMP.text = "Cirlce: " + scale;
            yield return null;
        }
        yield return StartCoroutine(Circle());
        running--;
    }
}
