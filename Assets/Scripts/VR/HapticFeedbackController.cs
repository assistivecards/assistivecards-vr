using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0, 1)]
    public float intensity;
    public float duration;

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}

public class HapticFeedbackController : MonoBehaviour
{
    public Haptic hapticOnSelectEnter;
    public Haptic hapticOnSelectExit;
    public Haptic hapticOnHoverEnter;
    public Haptic hapticOnHoverExit;
    public Haptic hapticOnActivate;

    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        interactable.selectEntered.AddListener(hapticOnSelectEnter.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticOnSelectExit.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticOnHoverEnter.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticOnHoverExit.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticOnActivate.TriggerHaptic);
    }

}
