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
    public float baseSpeed;
    bool dash;

    protected override void Start()
    {
        base.Start();
        dash = false;
        baseSpeed = speed;
    }

    protected override void FixedUpdate()
    {
        
        if (dash)
        {
            speed = 15;
            movement = destination - (Vector2) transform.position;

            if (movement.magnitude < 0.1) 
            {
                dash = false;
                speed = baseSpeed;
            }
        }
        base.FixedUpdate();
    }

    protected override void Attack()
    {
        
        dash = true;
        base.Attack();
        Instantiate(daggerPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
        Instantiate(daggerPrefab, spawnPointRight.position, spawnPointRight.rotation);
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
