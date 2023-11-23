using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampButtonRadius : MonoBehaviour
{
    bool isPressing;
    Transform pressingHand;
    [SerializeField] Transform rightHandModel;
    [SerializeField] Transform leftHandModel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poke")
        {
            pressingHand = other.name.Contains("r_index") ? rightHandModel : leftHandModel;
            EnablePokeAnim();
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
            else
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
