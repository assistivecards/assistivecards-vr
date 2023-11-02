using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandMenuPersistenceOnTeleportation : MonoBehaviour
{
    [SerializeField] GameObject handMenuCanvas;
    public static bool isHandMenuActive = false;

    private void Start()
    {
        gameObject.GetComponent<TeleportationProvider>().beginLocomotion += CheckIfHandMenuIsActive;
    }

    private void CheckIfHandMenuIsActive(LocomotionSystem system)
    {
        if (handMenuCanvas.activeInHierarchy)
        {
            isHandMenuActive = true;
        }
    }
}
