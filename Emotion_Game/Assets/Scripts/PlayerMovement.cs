using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3.5f;
    public float currentSpeed = 0f;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private float mx; //Horizontal Movement
    private float my; //Vertical Movement

    private void Update()
    {
        //Get Player Movement Input
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(mx, my).normalized;

        if (mx != 0 || my != 0)
        {
            currentSpeed += 1;
            if (currentSpeed > movementSpeed)
            {
                currentSpeed = movementSpeed;
            }
        }
        else
        {
            if (currentSpeed < 0)
            {
                currentSpeed -= 1;
            }
        }
    }

    private void FixedUpdate()
    {
        if (FindObjectOfType<DialogueManager>().talking != true && FindObjectOfType<NextDayTrigger>().promptOpen != true)
        {
            rb.velocity = new Vector2(moveDirection.x * currentSpeed, moveDirection.y * currentSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
