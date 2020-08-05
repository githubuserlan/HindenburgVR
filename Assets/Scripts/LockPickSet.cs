using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickSet : MonoBehaviour
{

    public GameObject Schloss;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Schloss)
        {
            Schloss.transform.GetChild(0).gameObject.SetActive(true);
            Schloss.transform.GetChild(1).gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
