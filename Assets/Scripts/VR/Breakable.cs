using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject brokenObject;
    public GameObject coinsParent;

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
            brokenObject.gameObject.SetActive(true);
            brokenObject.transform.SetParent(GameObject.Find("Room").transform);
            coinsParent.gameObject.SetActive(true);
            coinsParent.transform.SetParent(GameObject.Find("Room").transform);
            Destroy(gameObject);
        }
    }


}
