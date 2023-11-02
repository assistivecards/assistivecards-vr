using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandMenuPersistenceOnTeleportation : MonoBehaviour
{
    [SerializeField] GameObject handMenuCanvas;
    [SerializeField] GameObject settingsButtonCanvas;
    public static bool isHandMenuActive = false;
    public static bool isSettingsButtonActive = false;

    private void Start()
    {
        gameObject.GetComponent<TeleportationProvider>().beginLocomotion += CheckIfHandMenuIsActive;
        gameObject.GetComponent<TeleportationProvider>().beginLocomotion += CheckIfSettingsButtonIsActive;
    }

    private void CheckIfHandMenuIsActive(LocomotionSystem system)
    {
        if (handMenuCanvas.activeInHierarchy)
        {
            isHandMenuActive = true;
        }
    }

    private void CheckIfSettingsButtonIsActive(LocomotionSystem system)
    {
        if (settingsButtonCanvas.activeInHierarchy)
        {
            isSettingsButtonActive = true;
        }
    }
}
