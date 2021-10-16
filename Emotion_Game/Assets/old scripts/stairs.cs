using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairs : MonoBehaviour
{
    public bool nearStairs; //is the player within interacting distance?
    [SerializeField] Collider2D collider; //UI to show the thing

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) //when you press w...
        {

            if (nearStairs) // and you're within distance and you're not already interacting...
            {
                if (collider.enabled == false)
                {
                    collider.enabled = true;
                }
                else if (collider.enabled == true)
                {
                    collider.enabled = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)  //am in in distance?
    {
        if (col.gameObject.name.Equals("Player"))
        {
            nearStairs = true;
        }

    }

    void OnTriggerStay2D(Collider2D col)  //am in in distance?
    {
        if (col.gameObject.name.Equals("Player"))
        {
            nearStairs = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            nearStairs = false;
        }
    }


}

