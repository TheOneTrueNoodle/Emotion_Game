using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    
    public bool talking = false;
    public Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();

        foreach (var sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void Update()
    {
        if (talking == true)
        {
            if (Input.GetKeyDown("z"))
            {
                DisplayNextSentence();
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds((float) 0.04);
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of Conversation");
        StopAllCoroutines();
        dialogueText.text = "";
        talking = false;
    }
}
