using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandMenuController : MonoBehaviour
{
    public GameObject handMenuCanvas;
    // public GameObject indicatorCanvas;
    public GameObject settingsButtonCanvas;
    // public InputActionProperty menuButtonAction;
    // public bool isHandMenuAvailable;

    public void EnableHandMenu()
    {
        handMenuCanvas.SetActive(true);
        LeanTween.value(handMenuCanvas, UpdateHandMenuAlphaValue, 0, 1, .2f);
    }

    public void DisableHandMenu()
    {
        LeanTween.value(handMenuCanvas, UpdateHandMenuAlphaValue, handMenuCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => handMenuCanvas.SetActive(false));
    }

    // public void EnableIndicator()
    // {
    //     indicatorCanvas.SetActive(true);
    //     LeanTween.value(indicatorCanvas, UpdateIndicatorAlphaValue, 0, 1, .2f);
    // }

    // public void DisableIndicator()
    // {
    //     LeanTween.value(indicatorCanvas, UpdateIndicatorAlphaValue, indicatorCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => indicatorCanvas.SetActive(false));
    // }

    public void EnableSettingsButton()
    {
        settingsButtonCanvas.SetActive(true);
        LeanTween.value(settingsButtonCanvas, UpdateSettingsButtonAlphaValue, 0, 1, .2f);
    }

    public void DisableSettingsButton()
    {
        LeanTween.value(settingsButtonCanvas, UpdateSettingsButtonAlphaValue, settingsButtonCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => settingsButtonCanvas.SetActive(false));
    }

    void UpdateHandMenuAlphaValue(float val)
    {
        handMenuCanvas.GetComponent<CanvasGroup>().alpha = val;
    }

    void UpdateSettingsButtonAlphaValue(float val)
    {
        settingsButtonCanvas.GetComponent<CanvasGroup>().alpha = val;
    }

    // void UpdateIndicatorAlphaValue(float val)
    // {
    //     indicatorCanvas.GetComponent<CanvasGroup>().alpha = val;
    // }

    // public void AllowHandMenu()
    // {
    //     isHandMenuAvailable = true;
    // }

    // public void DisallowHandMenu()
    // {
    //     isHandMenuAvailable = false;
    // }

    // private void Update()
    // {
    //     if (isHandMenuAvailable)
    //     {
    //         if (menuButtonAction.action.triggered)
    //         {
    //             EnableHandMenu();
    //         }
    //     }
    // }
}
