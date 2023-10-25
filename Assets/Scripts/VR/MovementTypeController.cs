using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementTypeController : MonoBehaviour
{
    public bool canTeleport;
    GameAPI gameAPI;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ApplyMovementPreference();
    }

    // void Update()
    // {
    //     if (secondaryButtonAction.action.triggered)
    //     {
    //         gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled = !gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled;
    //         canTeleport = !canTeleport;
    //     }
    // }

    public void ApplyMovementPreference()
    {
        if (gameAPI.GetMovementTypePreference() == "Continuous")
        {
            gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
            canTeleport = false;
        }

        else if (gameAPI.GetMovementTypePreference() == "Teleportation")
        {
            gameObject.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            canTeleport = true;
        }
    }

}
