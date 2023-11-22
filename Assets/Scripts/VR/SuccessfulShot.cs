using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SuccessfulShot : MonoBehaviour
{
    public ParticleSystem successfulShotParticleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DartTip") && !other.transform.parent.GetComponent<XRGrabInteractable>().isSelected)
        {
            successfulShotParticleSystem.Play();
        }
    }
}
