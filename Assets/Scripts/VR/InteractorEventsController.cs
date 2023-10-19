using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InteractorEventsController : MonoBehaviour
{

    public void ParentGrabbableToInteractor(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.GetComponent<XRGrabInteractable>())
        {
            args.interactableObject.transform.SetParent(transform);
        }
    }

    public void HighlightGrabbable(HoverEnterEventArgs args)
    {
        args.interactableObject.transform.gameObject.GetComponent<Outline>().enabled = true;
    }

    public void DehighlightGrabbable(HoverExitEventArgs args)
    {
        args.interactableObject.transform.gameObject.GetComponent<Outline>().enabled = false;
    }
}
