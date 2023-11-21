using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = .5f;
    public Color fadeColor;
    private Renderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<Renderer>();

        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    public void Fade(float alphaFrom, float alphaTo)
    {
        StartCoroutine(FadeRoutine(alphaFrom, alphaTo));
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public IEnumerator FadeRoutine(float alphaFrom, float alphaTo)
    {
        float timer = 0;

        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaFrom, alphaTo, timer / fadeDuration);

            meshRenderer.material.SetColor("_BaseColor", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaTo;
        meshRenderer.material.SetColor("_BaseColor", newColor2);

    }
}
