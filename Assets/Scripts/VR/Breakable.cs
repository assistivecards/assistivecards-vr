using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject brokenObject;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            // Instantiate(brokenObject, transform.position, transform.rotation);
            // for (int i = 0; i < brokenObject.transform.childCount; i++)
            // {
            //     brokenObject.transform.GetChild(i).GetComponent<Rigidbody>().AddForce(other.relativeVelocity);
            // }

            // Destroy(gameObject);
            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }


}
