using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportRayVisualController : MonoBehaviour
{
    public InputActionProperty primaryButtonAction;
    public GameObject teleportRay;
    public float activationThreshold = 0.1f;

    void Update()
    {
        teleportRay.SetActive(CheckIfActivated());
    }

    public bool CheckIfActivated()
    {
        if (GetComponent<MovementTypeController>().canTeleport)
        {
            if (primaryButtonAction.action.ReadValue<float>() > activationThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
