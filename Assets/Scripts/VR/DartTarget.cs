using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("COLLIDED");
            transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
