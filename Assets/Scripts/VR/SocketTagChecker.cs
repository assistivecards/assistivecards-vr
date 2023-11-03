using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketTagChecker : MonoBehaviour
{
    private string targetTag = string.Empty;

    private void Start()
    {
        targetTag = gameObject.tag;
    }

    public void CheckTagOnHoverEnter(HoverEnterEventArgs args)
    {
        gameObject.GetComponent<XRSocketInteractor>().socketActive = args.interactableObject.transform.CompareTag(targetTag);
    }

    public void CheckTagOnHoverExit(HoverExitEventArgs args)
    {
        gameObject.GetComponent<XRSocketInteractor>().socketActive = args.interactableObject.transform.CompareTag(targetTag);
    }
}
