using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessfulShot : MonoBehaviour
{
    public ParticleSystem successfulShotParticleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DartTip"))
        {
            successfulShotParticleSystem.Play();
        }
    }
}
