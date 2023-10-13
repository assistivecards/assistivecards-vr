using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchBetweenTurnProviders : MonoBehaviour
{
    public InputActionProperty primaryButtonAction;

    void Update()
    {
        if (primaryButtonAction.action.triggered)
        {
            gameObject.GetComponent<ActionBasedContinuousTurnProvider>().enabled = !gameObject.GetComponent<ActionBasedContinuousTurnProvider>().enabled;
            gameObject.GetComponent<ActionBasedSnapTurnProvider>().enabled = !gameObject.GetComponent<ActionBasedSnapTurnProvider>().enabled;
        }
    }
}
