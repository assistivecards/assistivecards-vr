using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExcludeCurrentScene : MonoBehaviour
{
    public string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        foreach (Transform scene in transform)
        {
            if (scene.gameObject.name == currentSceneName)
            {
                scene.gameObject.SetActive(false);
            }
        }
    }
}
