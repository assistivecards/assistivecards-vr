using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessfulShotDetector : MonoBehaviour
{
    public ParticleSystem successfulShotParticleSystem;
    public HoopCheckpoint checkpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball") && checkpoint.checkpointPassed)
        {
            successfulShotParticleSystem.Play();
            checkpoint.checkpointPassed = false;
        }
    }
}
