using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            // transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
            transform.parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            if (transform.parent.gameObject.GetComponent<Rigidbody>().constraints != RigidbodyConstraints.None)
            {
                transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
