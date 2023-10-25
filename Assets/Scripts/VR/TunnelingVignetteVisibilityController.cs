using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelingVignetteVisibilityController : MonoBehaviour
{
    GameAPI gameAPI;
    [SerializeField] GameObject tunnelingVignette;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();
    }

    private void Start()
    {
        ApplyVignettePreference();
    }

    public void ApplyVignettePreference()
    {
        if (gameAPI.GetTunnelingVignettePreference() == 1)
        {
            tunnelingVignette.SetActive(true);
        }

        else if (gameAPI.GetTunnelingVignettePreference() == 0)
        {
            tunnelingVignette.SetActive(false);
        }
    }

}
