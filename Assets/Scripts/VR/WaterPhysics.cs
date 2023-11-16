using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterPhysics : MonoBehaviour
{
    [SerializeField] XRBaseInteractor rightController;
    [SerializeField] XRBaseInteractor leftController;
    public GameObject water;
    public GameObject mesh;

    private int sloshSpeed = 60;
    private int rotateSpeed = 15;

    private int difference = 25;

    void Update()
    {
        if (rightController.interactablesSelected.Count != 0)
        {
            if (rightController.interactablesSelected[0].transform.name == "WateringCan New")
            {
                Slosh();
                mesh.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
            }
        }
        else if (leftController.interactablesSelected.Count != 0)
        {
            if (leftController.interactablesSelected[0].transform.name == "WateringCan New")
            {
                Slosh();
                mesh.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
            }
        }
    }

    private void Slosh()
    {
        Quaternion inverseRotation = Quaternion.Inverse(GetComponent<XRGrabInteractable>().interactorsSelecting[0].transform.localRotation);
        Vector3 finalRotation = Quaternion.RotateTowards(water.transform.localRotation, inverseRotation, sloshSpeed * Time.deltaTime).eulerAngles;

        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        water.transform.localEulerAngles = finalRotation;
    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f;

        if (value > 180)
        {
            returnValue = Mathf.Clamp(value, 360 - difference, 360);
        }

        else
        {
            returnValue = Mathf.Clamp(value, 0, difference);
        }

        return returnValue;
    }
}
