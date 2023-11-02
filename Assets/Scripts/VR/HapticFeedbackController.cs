using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedbackController : MonoBehaviour
{
    GameAPI gameAPI;
    public static bool canVibrate;
    public Haptic hapticOnUIInteraction;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void Start()
    {
        ApplyHapticFeedbackPreference();
    }

    public void ApplyHapticFeedbackPreference()
    {
        if (gameAPI.GetHapticsPreference() == 1)
        {
            canVibrate = true;
        }

        else if (gameAPI.GetHapticsPreference() == 0)
        {
            canVibrate = false;
        }
    }

    public void TriggerHapticOnUIInteraction(XRBaseController controller)
    {
        if (hapticOnUIInteraction.intensity > 0 && canVibrate)
        {
            controller.SendHapticImpulse(hapticOnUIInteraction.intensity, hapticOnUIInteraction.duration);
        }
    }

}
