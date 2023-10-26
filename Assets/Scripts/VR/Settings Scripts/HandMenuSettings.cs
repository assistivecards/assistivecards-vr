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
    public MovementTypeController movementTypeController;
    public RotationTypeController rotationTypeController;
    public TunnelingVignetteVisibilityController tunnelingVignetteVisibilityController;
    [SerializeField] Button controlsSaveButton;
    [SerializeField] Button audioSaveButton;
    private bool enableSaveButton;
    TMP_Text text;
    Color color;
    Color fadeoutcolor;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void OnEnable()
    {
        controlsSaveButton.interactable = false;
        audioSaveButton.interactable = false;
        enableSaveButton = false;

        text = controlsSaveButton.transform.GetChild(0).GetComponent<TMP_Text>();
        color = text.color;
        fadeoutcolor = color;
        fadeoutcolor.a = .5f;
        LeanTween.value(gameObject, updateValueExampleCallback, color, fadeoutcolor, .2f);
    }

    void Start()
    {
        GetPreferences();
        continuousMovementToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        continuousRotationToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        tunnelingVignetteOnToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
    }

    private void GetPreferences()
    {
        continuousMovementToggle.isOn = gameAPI.GetMovementTypePreference() == "Continuous" ? true : false;
        teleportationMovementToggle.isOn = gameAPI.GetMovementTypePreference() == "Teleportation" ? true : false;
        continuousRotationToggle.isOn = gameAPI.GetRotationTypePreference() == "Continuous" ? true : false;
        snapRotationToggle.isOn = gameAPI.GetRotationTypePreference() == "Snap" ? true : false;
        tunnelingVignetteOnToggle.isOn = gameAPI.GetTunnelingVignettePreference() == 1 ? true : false;
        tunnelingVignetteOffToggle.isOn = gameAPI.GetTunnelingVignettePreference() == 0 ? true : false;
    }

    public void OnSaveSettingsButtonClick()
    {
        gameAPI.SetMovementTypePreference(continuousMovementToggle.isOn ? "Continuous" : "Teleportation");
        gameAPI.SetRotationTypePreference(continuousRotationToggle.isOn ? "Continuous" : "Snap");
        gameAPI.SetTunnelingVignettePreference(tunnelingVignetteOnToggle.isOn ? 1 : 0);

        movementTypeController.ApplyMovementPreference();
        rotationTypeController.ApplyRotationPreference();
        tunnelingVignetteVisibilityController.ApplyVignettePreference();

        controlsSaveButton.interactable = false;
        audioSaveButton.interactable = false;
        enableSaveButton = false;
        LeanTween.value(gameObject, updateValueExampleCallback, color, fadeoutcolor, .2f);
    }

    private void Update()
    {
        if ((controlsSaveButton.interactable == false && audioSaveButton.interactable == false) && enableSaveButton)
        {
            controlsSaveButton.interactable = true;
            audioSaveButton.interactable = true;
            LeanTween.value(gameObject, updateValueExampleCallback, fadeoutcolor, color, .2f);
        }
    }

    private void EnableSaveButton()
    {
        enableSaveButton = true;
    }

    void updateValueExampleCallback(Color val)
    {
        text.color = val;
    }


}
