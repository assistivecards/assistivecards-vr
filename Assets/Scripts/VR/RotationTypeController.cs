using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationTypeController : MonoBehaviour
{
    GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ApplyRotationPreference();
    }

    // void Update()
    // {
    //     if (primaryButtonAction.action.triggered)
    //     {
    //         gameObject.GetComponent<ActionBasedContinuousTurnProvider>().enabled = !gameObject.GetComponent<ActionBasedContinuousTurnProvider>().enabled;
    //         gameObject.GetComponent<ActionBasedSnapTurnProvider>().enabled = !gameObject.GetComponent<ActionBasedSnapTurnProvider>().enabled;
    //     }
    // }

    public void ApplyRotationPreference()
    {
        if (gameAPI.GetRotationTypePreference() == "Continuous")
        {
            gameObject.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
            gameObject.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
        }

        else if (gameAPI.GetRotationTypePreference() == "Snap")
        {
            gameObject.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
            gameObject.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
        }
    }

}
