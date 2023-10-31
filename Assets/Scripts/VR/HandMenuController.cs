using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandMenuController : MonoBehaviour
{
    public GameObject handMenuCanvas;
    // public GameObject indicatorCanvas;
    public GameObject settingsButtonCanvas;
    // public InputActionProperty menuButtonAction;
    // public bool isHandMenuAvailable;
    public XRDirectInteractor leftInteractor;
    public XRDirectInteractor rightInteractor;
    public bool isHoveringUI;

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
        if (!leftInteractor.hasSelection && !rightInteractor.hasSelection)
        {
            settingsButtonCanvas.SetActive(true);
            LeanTween.value(settingsButtonCanvas, UpdateSettingsButtonAlphaValue, 0, 1, .2f);
        }

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

    private void Update()
    {
        if (isHoveringUI)
        {
            rightInteractor.transform.GetChild(0).GetComponent<Animator>().SetFloat("Poke", 1, .07f, Time.deltaTime);
        }
        else if (!isHoveringUI)
        {
            rightInteractor.transform.GetChild(0).GetComponent<Animator>().SetFloat("Poke", 0, .07f, Time.deltaTime);
        }
    }

    public void EnablePokeAnim()
    {
        isHoveringUI = true;
    }

    public void DisablePokeAnim()
    {
        isHoveringUI = false;
    }
}
