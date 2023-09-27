using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spinner : MonoBehaviour
{
    private RectTransform rectComponent;
    private Image imageComp;
    private bool up;

    public float rotateSpeed = 200f;
    public float openSpeed = .005f;
    public float closeSpeed = .01f;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        up = true;
    }

    private void Update()
    {
        rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        changeSize();
    }

    private void changeSize()
    {
        float currentSize = imageComp.fillAmount;

        if (currentSize < .30f && up)
        {
            imageComp.fillAmount += openSpeed * Time.deltaTime;
        }
        else if (currentSize >= .30f && up)
        {
            up = false;
        }
        else if (currentSize >= .02f && !up)
        {
            imageComp.fillAmount -= closeSpeed * Time.deltaTime;
        }
        else if (currentSize < .02f && !up)
        {
            up = true;
        }
    }
}
