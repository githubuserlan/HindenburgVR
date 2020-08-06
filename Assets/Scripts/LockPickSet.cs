using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickSet : MonoBehaviour
{

    public GameObject Schloss;

    private void OnTriggerEnter(Collider other)  
    {
        if(other.gameObject.name== "TürSchloss")
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Dietrich hingesetzt0");
            Destroy(this.gameObject);
        }
    }
}
