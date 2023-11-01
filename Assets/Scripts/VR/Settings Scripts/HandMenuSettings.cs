using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandMenuSettings : MonoBehaviour
{
    GameAPI gameAPI;

    public Toggle continuousMovementToggle;
    public Toggle teleportationMovementToggle;
    public Toggle continuousRotationToggle;
    public Toggle snapRotationToggle;
    public Toggle tunnelingVignetteOnToggle;
    public Toggle tunnelingVignetteOffToggle;
    public Toggle hapticFeedbackOnToggle;
    public Toggle hapticFeedbackOffToggle;
    public MovementTypeController movementTypeController;
    public RotationTypeController rotationTypeController;
    public TunnelingVignetteVisibilityController tunnelingVignetteVisibilityController;
    public HapticFeedbackController hapticFeedbackController;
    [SerializeField] Button controlsSaveButton;
    [SerializeField] Button audioSaveButton;
    [SerializeField] Button miscSaveButton;
    private bool enableSaveButton;
    TMP_Text controlsSaveButtonText;
    TMP_Text audioSaveButtonText;
    TMP_Text miscSaveButtonText;
    Color color;
    Color fadeoutcolor;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable()
    {
        GetPreferences();
        controlsSaveButton.interactable = false;
        audioSaveButton.interactable = false;
        miscSaveButton.interactable = false;
        enableSaveButton = false;

        controlsSaveButtonText = controlsSaveButton.transform.GetChild(0).GetComponent<TMP_Text>();
        audioSaveButtonText = audioSaveButton.transform.GetChild(0).GetComponent<TMP_Text>();
        miscSaveButtonText = miscSaveButton.transform.GetChild(0).GetComponent<TMP_Text>();
        color = controlsSaveButtonText.color;
        fadeoutcolor = color;
        fadeoutcolor.a = .5f;
        LeanTween.value(gameObject, UpdateValue, color, fadeoutcolor, .2f);
    }

    void Start()
    {
        continuousMovementToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        continuousRotationToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        tunnelingVignetteOnToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        hapticFeedbackOnToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
    }

    private void GetPreferences()
    {
        continuousMovementToggle.isOn = gameAPI.GetMovementTypePreference() == "Continuous" ? true : false;
        teleportationMovementToggle.isOn = gameAPI.GetMovementTypePreference() == "Teleportation" ? true : false;
        continuousRotationToggle.isOn = gameAPI.GetRotationTypePreference() == "Continuous" ? true : false;
        snapRotationToggle.isOn = gameAPI.GetRotationTypePreference() == "Snap" ? true : false;
        tunnelingVignetteOnToggle.isOn = gameAPI.GetTunnelingVignettePreference() == 1 ? true : false;
        tunnelingVignetteOffToggle.isOn = gameAPI.GetTunnelingVignettePreference() == 0 ? true : false;
        hapticFeedbackOnToggle.isOn = gameAPI.GetHapticsPreference() == 0 ? true : false;
        hapticFeedbackOffToggle.isOn = gameAPI.GetHapticsPreference() == 0 ? true : false;
    }

    public void OnSaveSettingsButtonClick()
    {
        gameAPI.SetMovementTypePreference(continuousMovementToggle.isOn ? "Continuous" : "Teleportation");
        gameAPI.SetRotationTypePreference(continuousRotationToggle.isOn ? "Continuous" : "Snap");
        gameAPI.SetTunnelingVignettePreference(tunnelingVignetteOnToggle.isOn ? 1 : 0);
        gameAPI.SetHapticsPreference(hapticFeedbackOnToggle.isOn ? 1 : 0);

        movementTypeController.ApplyMovementPreference();
        rotationTypeController.ApplyRotationPreference();
        tunnelingVignetteVisibilityController.ApplyVignettePreference();
        hapticFeedbackController.ApplyHapticFeedbackPreference();

        controlsSaveButton.interactable = false;
        audioSaveButton.interactable = false;
        miscSaveButton.interactable = false;
        enableSaveButton = false;
        LeanTween.value(gameObject, UpdateValue, color, fadeoutcolor, .2f);
    }

    private void Update()
    {
        if ((controlsSaveButton.interactable == false && audioSaveButton.interactable == false && miscSaveButton.interactable == false) && enableSaveButton)
        {
            controlsSaveButton.interactable = true;
            audioSaveButton.interactable = true;
            miscSaveButton.interactable = true;
            color.a = 1;
            LeanTween.value(gameObject, UpdateValue, fadeoutcolor, color, .2f);
        }
    }

    private void EnableSaveButton()
    {
        enableSaveButton = true;
    }

    void UpdateValue(Color val)
    {
        controlsSaveButtonText.color = val;
        audioSaveButtonText.color = val;
        miscSaveButtonText.color = val;
    }


}
