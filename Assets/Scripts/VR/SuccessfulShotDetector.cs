using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessfulShotDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem successfulShotParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            successfulShotParticleSystem.Play();
        }
    }
}
