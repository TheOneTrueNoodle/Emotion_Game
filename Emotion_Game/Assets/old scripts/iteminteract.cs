using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iteminteract : MonoBehaviour
{
    bool onInteractable; //is the player within interacting distance?
    bool interacting; //player is looking at UI (code in no movement with this variable)
    [SerializeField] int ID;
    [SerializeField] Canvas canvas; //UI to show the thing
    [SerializeField] Animator animator; //animator to make a sparkle

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z")) //when you press z...
        {

            if (onInteractable) // and you're within distance and you're not already interacting...
            {
                if (canvas.enabled == false)
                {
                    canvas.enabled = true;
                }
                else if (canvas.enabled == true)
                {
                    canvas.enabled = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)  //am in in distance?
    {
        if (col.gameObject.name.Equals("Player"))
        {
            onInteractable = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            onInteractable = false;
        }
    }


}