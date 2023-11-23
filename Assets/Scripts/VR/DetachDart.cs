using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetachDart : MonoBehaviour
{
    public void DetachDartFromBoard(SelectEnterEventArgs args)
    {
        if (gameObject.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.None)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }

        gameObject.GetComponent<DartThrowPhysics>().hit = false;
    }
}
