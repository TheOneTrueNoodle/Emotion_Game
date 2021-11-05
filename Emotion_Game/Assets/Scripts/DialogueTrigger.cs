using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playerNear = false;
    public AudioSource SoundFX;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
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
                FindObjectOfType<DialogueManager>().StopAllCoroutines();
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
                if (Input.GetKeyDown("z") || Input.GetKeyDown("e")) //when you press z or E...
                {
                    FindObjectOfType<DialogueManager>().finishedTalking = false;
                    TriggerDialogue();
                }
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        playerNear = false;
        canvas.SetActive(false);
        FindObjectOfType<DialogueManager>().talking = true;

        if (SoundFX != null)
        {
            if (!SoundFX.isPlaying)
            {
                SoundFX.Play();
            }
        }
    }
}
