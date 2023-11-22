using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartThrowPhysics : MonoBehaviour
{
    public List<Vector3> trackingPos = new List<Vector3>();
    public float velocity;

    private void Update()
    {

        if (trackingPos.Count > 15)
        {
            trackingPos.RemoveAt(0);
        }

        if (GetComponent<XRGrabInteractable>().isSelected)
        {
            trackingPos.Add(transform.gameObject.GetComponent<XRGrabInteractable>().interactorsSelecting[0].transform.position);
        }

    }

    public void ThrowDart(SelectExitEventArgs args)
    {
        transform.Rotate(Vector3.right, -50);
        Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
        GetComponent<Rigidbody>().AddForce(direction * velocity);
    }
}
