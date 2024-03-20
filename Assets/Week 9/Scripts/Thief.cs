using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float dashSpeed;
    Coroutine dashing;

    IEnumerator Dash()
    {
        speed += dashSpeed;
        while (speed > baseSpeed)
        {
            yield return null;
        }
        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(daggerPrefab, spawnPointLeft.position, spawnPointLeft.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(daggerPrefab, spawnPointRight.position, spawnPointRight.rotation);
    }

    protected override void Attack()
    {
       destination = Camera.main.ScreenToWorldPoint(Input.mousePosition); // updates on mouse clicks.
       if (dashing != null)
        {
            StopCoroutine(dashing);
        }
        dashing = StartCoroutine(Dash());
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
