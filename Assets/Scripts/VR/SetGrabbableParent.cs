using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SetGrabbableParent : MonoBehaviour
{

    public void ParentGrabbableToInteractor(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.SetParent(transform);
    }
}
