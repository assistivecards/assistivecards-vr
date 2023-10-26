using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateHandMenuIndicator : MonoBehaviour
{
    public float timerDuration = 3f;
    public Slider indicator;

    float timer;

    private void OnEnable()
    {
        timer = timerDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        float normalizedTime = Mathf.Clamp01(timer / timerDuration);
        indicator.value = normalizedTime;
    }
}
