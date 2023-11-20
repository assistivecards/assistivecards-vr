using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetEraserPosition : MonoBehaviour
{
    [SerializeField] XRSocketInteractorWithTagCheck eraserSocket;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Invoke(nameof(ResetEraserPos), 5f);
        }
    }

    public void ResetEraserPos()
    {
        if (!GetComponent<XRGrabInteractable>().isSelected)
        {
            transform.position = eraserSocket.transform.position;
        }
    }
}
