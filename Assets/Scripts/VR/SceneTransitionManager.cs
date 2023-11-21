using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeScreenRoutine(sceneName));
    }

    IEnumerator ChangeScreenRoutine(string sceneName)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneName);
    }
}
