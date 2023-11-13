using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Debug.Log("COLLIDED");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
