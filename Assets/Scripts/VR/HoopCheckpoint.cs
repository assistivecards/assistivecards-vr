using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopCheckpoint : MonoBehaviour
{
    public bool checkpointPassed;

    private void OnTriggerEnter(Collider other)
    {
        checkpointPassed = true;
    }
}
