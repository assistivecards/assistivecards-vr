using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] GameObject lampLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poke")
        {
            lampLight.SetActive(!lampLight.activeInHierarchy);
        }
    }

}
