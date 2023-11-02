using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandMenuController : MonoBehaviour
{
    public GameObject handMenuCanvas;
    public GameObject settingsButtonCanvas;
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
        if (HandMenuPersistenceOnTeleportation.isHandMenuActive == false)
        {
            LeanTween.value(handMenuCanvas, UpdateHandMenuAlphaValue, handMenuCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => handMenuCanvas.SetActive(false));
        }

        HandMenuPersistenceOnTeleportation.isHandMenuActive = false;
    }

    public void EnableSettingsButton()
    {
        if (!leftInteractor.hasSelection && !rightInteractor.hasSelection && !handMenuCanvas.activeInHierarchy)
        {
            settingsButtonCanvas.SetActive(true);
            LeanTween.value(settingsButtonCanvas, UpdateSettingsButtonAlphaValue, 0, 1, .2f);
        }

    }

    public void DisableSettingsButton()
    {
        if (HandMenuPersistenceOnTeleportation.isSettingsButtonActive == false)
        {
            LeanTween.value(settingsButtonCanvas, UpdateSettingsButtonAlphaValue, settingsButtonCanvas.GetComponent<CanvasGroup>().alpha, 0, .2f).setOnComplete(() => settingsButtonCanvas.SetActive(false));
        }

        HandMenuPersistenceOnTeleportation.isSettingsButtonActive = false;
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
            rightInteractor.transform.GetChild(0).GetComponent<Animator>().SetFloat("Poke", 1, .1f, Time.deltaTime);
        }
        else if (!isHoveringUI)
        {
            rightInteractor.transform.GetChild(0).GetComponent<Animator>().SetFloat("Poke", 0, .1f, Time.deltaTime);
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
