using System;
using System.Collections;
using System.Collections.Generic;
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
    private bool enableSaveButton = false;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    void Start()
    {
        GetPreferences();
        continuousMovementToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        // teleportationMovementToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        continuousRotationToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
        // snapRotationToggle.onValueChanged.AddListener(delegate { EnableSaveButton(); });
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
    }

    private void Update()
    {
        if ((controlsSaveButton.interactable == false && audioSaveButton.interactable == false) && enableSaveButton)
        {
            controlsSaveButton.interactable = true;
            audioSaveButton.interactable = true;
        }
    }

    private void EnableSaveButton()
    {
        enableSaveButton = true;
    }


}
