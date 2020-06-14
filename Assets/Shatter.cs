using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject destroyedVersion;

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.GetComponent<Rigidbody>().velocity.magnitude < 2)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Debug.Log(this.gameObject.name + " velocity is " + this.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
    }
}
