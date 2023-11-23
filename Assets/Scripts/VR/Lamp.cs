using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] GameObject lampLight;
    bool isPressing;
    Transform pressingHand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poke")
        {
            pressingHand = other.name.Contains("r_index") ? GameObject.Find("Right Hand Model").transform : GameObject.Find("Left Hand Model").transform;
            EnablePokeAnim();
            lampLight.SetActive(!lampLight.activeInHierarchy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisablePokeAnim();
    }

    private void Update()
    {
        if (pressingHand != null)
        {
            if (isPressing)
            {
                pressingHand.GetComponent<Animator>().SetFloat("Poke", 1, .1f, Time.deltaTime);
            }
            else if (!isPressing)
            {
                pressingHand.GetComponent<Animator>().SetFloat("Poke", 0, .1f, Time.deltaTime);
            }
        }

    }

    public void EnablePokeAnim()
    {
        isPressing = true;
    }

    public void DisablePokeAnim()
    {
        isPressing = false;
    }
}
