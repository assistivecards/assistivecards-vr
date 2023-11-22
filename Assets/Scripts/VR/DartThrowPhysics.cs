using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartThrowPhysics : MonoBehaviour
{
    public List<Vector3> trackingPos = new List<Vector3>();
    public float velocity;
    public bool hit;

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
        var hitColliders = Physics.OverlapBox(transform.GetChild(0).GetComponent<BoxCollider>().bounds.center, transform.GetChild(0).GetComponent<BoxCollider>().size / 2, Quaternion.identity);

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Target"))
            {
                hit = true;
            }
        }

        if (!hit)
        {
            transform.Rotate(Vector3.right, -50);
        }

        Vector3 direction = trackingPos[trackingPos.Count - 1] - trackingPos[0];
        GetComponent<Rigidbody>().AddForce(direction * velocity);
    }
}
