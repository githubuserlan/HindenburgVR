using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float speed;
    public float DestroySpeed;
    public bool SpeedIsThere;


    private void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (SpeedIsThere)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        speed = this.GetComponent<Rigidbody>().velocity.magnitude;
        if (speed>DestroySpeed)
        { SpeedIsThere = true;
            Debug.Log("SpeedisThere"); }
        else { SpeedIsThere = false; }
    }
}
