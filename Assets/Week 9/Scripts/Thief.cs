using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    Vector3 dashPosition;
    public Vector3 dashDistance;
    float baseSpeed;
    bool dash = false;

    protected override void FixedUpdate()
    {
        baseSpeed = speed; //stores base value
        if (dash)
        {
            speed = baseSpeed * 3;
        }
        base.FixedUpdate();

    }

    protected override void Attack()
    {
        
        dash = true;
        base.Attack();
        Instantiate(daggerPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
        Instantiate(daggerPrefab, spawnPointRight.position, spawnPointRight.rotation);
        dash = false;


        destination = transform.position;
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
