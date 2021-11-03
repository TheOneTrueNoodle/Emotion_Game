using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Stairs"))
        {
            runSpeed = 20.0f;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Stairs"))
        {
            runSpeed = 20.0f;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Stairs"))
        {
            runSpeed = 10.0f;
        }
    }
}