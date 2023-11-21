using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public void DetectSelectedScene()
    {
        // SceneManager.LoadScene(gameObject.name);
        GameObject.Find("Transition Manager").GetComponent<SceneTransitionManager>().ChangeScene(gameObject.name);
    }
}
