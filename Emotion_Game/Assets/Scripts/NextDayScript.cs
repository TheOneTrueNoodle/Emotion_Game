using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextDayScript : MonoBehaviour
{
    public Animator transition;
    public float TransitionTime = 1f;
    public string NextDay;

    public void StartTransition()
    {
        StartCoroutine(LoadDay());
    }

    IEnumerator LoadDay()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextDay, LoadSceneMode.Additive);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
