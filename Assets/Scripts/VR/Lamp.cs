using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    [SerializeField] GameObject lampLight;
    private Vector3 pos1 = new Vector3(-0.003197f, -0.0053f, 8.7e-05f);
    private Vector3 pos2 = new Vector3(-0.003104f, -0.0053f, -3e-05f);
    private Vector3 rot1 = new Vector3(0, 0, 0);
    private Vector3 rot2 = new Vector3(180, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Poke")
        {
            lampLight.SetActive(!lampLight.activeInHierarchy);

            if (transform.parent.localEulerAngles.x == 0)
            {
                transform.parent.localEulerAngles = rot2;
                transform.parent.localPosition = pos2;
            }

            else
            {
                transform.parent.localEulerAngles = rot1;
                transform.parent.localPosition = pos1;
            }

        }
    }

}
