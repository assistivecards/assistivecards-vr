using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchBetweenMovementModes : MonoBehaviour
{
    public InputActionProperty secondaryButtonAction;
    public bool canTeleport;

    void Update()
    {
        if (secondaryButtonAction.action.triggered)
        {
            gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled = !gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled;
            canTeleport = !canTeleport;
        }
    }
}
