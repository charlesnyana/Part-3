using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WithoutCoroutines : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;

    bool inMotion = false;
    float time = 0;
    float interpolation = 0;
    bool forward = false;
    bool turning = false;
    float moveFactor;
    float turnFactor;
    Quaternion currentHeading;
    Quaternion newHeading;


    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
  
    }

    private void Update()
    {
        
        if (inMotion)
        {
            
            if (forward)
            {
                if (time < moveFactor)
                {
                    time += Time.deltaTime;
                    missile.transform.Translate(transform.right * speed * Time.deltaTime);
                }
                else
                {
                    Debug.Log("moving done");
                    forward = false;
                }
            }
            if (turning)
            {
                if (interpolation < 1)
                {
                    interpolation += Time.deltaTime;
                    missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
                    missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
                    Debug.Log(interpolation);
                } 
                else
                {
                    Debug.Log("turning done");
                    turning = false;
                }
            }
        }
        else
        {
            moveFactor = 0;
            interpolation = 0;
            inMotion = false;
            turnFactor = 0;
        }
    }

    public void MakeTurn(float turn)
    {
       
        turning = true;
        inMotion = true;
        turnFactor = turn;
        moveFactor = 1;
        interpolation = 0;
        currentHeading = missile.transform.rotation;
        newHeading = currentHeading * Quaternion.Euler(0, 0, turnFactor);
    }

    public void MoveForwards(float length)
    {
       forward = true;
       inMotion = true;
       moveFactor = length;
        time = 0;
    }

    //IEnumerator RunLeg(float legLength)
    //{
    //    float time = 0;
    //    while (time < legLength)
    //    {
    //        time += Time.deltaTime;
    //        missile.transform.Translate(transform.right * speed * Time.deltaTime);
    //        yield return null;
    //    }
    //}

    //IEnumerator Turn(float turn)
    //{
    //    float interpolation = 0;
    //    Quaternion currentHeading = missile.transform.rotation;
    //    Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, turn);
    //    while (interpolation < 1)
    //    {
    //        interpolation += Time.deltaTime;
    //        missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
    //        missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
    //        yield return null;
    //    }
    //}
}
