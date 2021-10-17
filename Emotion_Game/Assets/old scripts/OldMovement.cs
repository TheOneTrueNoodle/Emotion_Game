using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    private float mx; //Horizontal Movement
    private float my; //Vertical Movement

    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");

        if (mx != 0) { transform.localScale = new Vector3(mx, 1f, 1f); }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, my * movementSpeed);

        rb.velocity = movement;
    }

}