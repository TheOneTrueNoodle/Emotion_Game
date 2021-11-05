using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayTrigger : MonoBehaviour
{
    private bool playerNear = false;
    public bool promptOpen = false;
    public AudioSource SoundFX;
    public GameObject canvas;
    public GameObject prompt;

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
        }
    }

    public void Update()
    {
        if (playerNear == true)
        {
            if (Input.GetKeyDown("z") || Input.GetKeyDown("e")) //when you press z or E...
            {
                PromptSleep();
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void PromptSleep()
    {
        playerNear = false;
        canvas.SetActive(false);
        prompt.SetActive(true);
        promptOpen = true;

        if (SoundFX != null)
        {
            if (!SoundFX.isPlaying)
            {
                SoundFX.Play();
            }
        }
    }

    public void dontSleep()
    {
        prompt.SetActive(false);
        promptOpen = false;
    }

    public void Sleep()
    {
        prompt.SetActive(false);
        FindObjectOfType<NextDayScript>().StartTransition();
    }
}
