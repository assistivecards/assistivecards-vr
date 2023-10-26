using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuController : MonoBehaviour
{
    public GameObject handMenuCanvas;

    public void EnableHandMenu()
    {
        handMenuCanvas.SetActive(true);
        LeanTween.value(handMenuCanvas, UpdateValue, 0, 1, .2f);
    }

    public void DisableHandMenu()
    {
        LeanTween.value(handMenuCanvas, UpdateValue, handMenuCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => handMenuCanvas.SetActive(false));
    }

    void UpdateValue(float val)
    {
        handMenuCanvas.GetComponent<CanvasGroup>().alpha = val;
    }
}
