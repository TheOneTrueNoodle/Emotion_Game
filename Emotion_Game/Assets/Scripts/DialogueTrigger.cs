﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playerNear = false;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Okay so its getting detected");
        if (other.tag == "Player")
        {
            playerNear = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerNear = false;
            canvas.SetActive(false);

            if (FindObjectOfType<DialogueManager>().talking == true)
            {
                FindObjectOfType<DialogueManager>().sentences.Clear();
                FindObjectOfType<DialogueManager>().dialogueText.text = "";
            }
        }
    }

    public void Update()
    {
        if (playerNear == true)
        {
            if (FindObjectOfType<DialogueManager>().talking != true)
            {
                if (Input.GetKeyDown("z")) //when you press z...
                {
                    TriggerDialogue();
                }
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().talking = true;
        playerNear = false;
        
        canvas.SetActive(false);
    }
}