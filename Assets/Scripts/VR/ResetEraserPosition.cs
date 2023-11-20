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
            StartCoroutine("ResetEraserPositionCoroutine");
        }
    }

    IEnumerator ResetEraserPositionCoroutine()
    {
        yield return new WaitForSeconds(5);
        transform.position = eraserSocket.transform.position;
        eraserSocket.interactablesSelected[0] = GetComponent<XRGrabInteractable>();
    }
}
