using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleLoader : MonoBehaviour
{
    public Animator transition;
    public float animationDelay = 1f;

    public void startBattle()
    {
        // Gets the next map based on it's name
        StartCoroutine(loadScene("BattleScene"));
    }

    IEnumerator loadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        // Waits for x amounts of seconds and then continues into the next line
        yield return new WaitForSeconds(animationDelay);

        SceneManager.LoadScene(sceneName);
    }
}
