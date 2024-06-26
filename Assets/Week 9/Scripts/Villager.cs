using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Villager : MonoBehaviour
{
    protected Rigidbody2D rb;
    Animator animator;

    bool clickingOnSelf;
    protected bool isSelected;
    public GameObject highlight;

    protected Vector2 destination;
    protected Vector2 movement;
    protected float speed = 3;
    protected float baseSpeed;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        baseSpeed = speed;
        destination = transform.position;
        Selected(false);
    }
    public void Selected(bool value)
    {
        isSelected = value;
        highlight.SetActive(isSelected);
    }

    //private void OnMouseDown()
    //{
    //    CharacterControl.SetSelectedVillager(this);
    //    clickingOnSelf = true;
    //}

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    protected virtual void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        //flip the x direction of the game object & children to face the direction we're walking
        if(movement.x > 0)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, 1 * transform.localScale.y, 1);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(1 * transform.localScale.x, 1 * transform.localScale.y, 1);
        }

        //stop moving if we're close enough to the target
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
            speed = baseSpeed;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        //left click: move to the click location
        if (Input.GetMouseButtonDown(0) && isSelected && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Movement", movement.magnitude);

        //right click to attack
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public virtual ChestType CanOpen()
    {
        return ChestType.Villager;
    }
}
