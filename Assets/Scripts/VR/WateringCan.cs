using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WateringCan : MonoBehaviour
{
    [SerializeField] ParticleSystem waterParticleSystem;
    [SerializeField] XRBaseInteractor rightController;
    [SerializeField] XRBaseInteractor leftController;

    void Update()
    {
        if (rightController.interactablesSelected.Count != 0)
        {
            if (rightController.interactablesSelected[0].transform.name == "WateringCan" && Vector3.Angle(Vector3.down, rightController.transform.forward) <= 50)
            {
                waterParticleSystem.Play();
            }

            else
            {
                waterParticleSystem.Stop();
            }
        }

        else if (leftController.interactablesSelected.Count != 0)
        {
            if (leftController.interactablesSelected[0].transform.name == "WateringCan" && Vector3.Angle(Vector3.down, leftController.transform.forward) <= 50)
            {
                waterParticleSystem.Play();
            }

            else
            {
                waterParticleSystem.Stop();
            }
        }

        else
        {
            waterParticleSystem.Stop();
        }
    }
}
