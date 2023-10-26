using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuController : MonoBehaviour
{
    public GameObject handMenuCanvas;
    public GameObject indicatorCanvas;

    public void EnableHandMenu()
    {
        handMenuCanvas.SetActive(true);
        LeanTween.value(handMenuCanvas, UpdateHandMenuAlphaValue, 0, 1, .2f);
    }

    public void DisableHandMenu()
    {
        LeanTween.value(handMenuCanvas, UpdateHandMenuAlphaValue, handMenuCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => handMenuCanvas.SetActive(false));
    }

    public void EnableIndicator()
    {
        indicatorCanvas.SetActive(true);
        LeanTween.value(indicatorCanvas, UpdateIndicatorAlphaValue, 0, 1, .2f);
    }

    public void DisableIndicator()
    {
        LeanTween.value(indicatorCanvas, UpdateIndicatorAlphaValue, indicatorCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => indicatorCanvas.SetActive(false));
    }

    void UpdateHandMenuAlphaValue(float val)
    {
        handMenuCanvas.GetComponent<CanvasGroup>().alpha = val;
    }

    void UpdateIndicatorAlphaValue(float val)
    {
        indicatorCanvas.GetComponent<CanvasGroup>().alpha = val;
    }
}
