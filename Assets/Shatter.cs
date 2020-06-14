using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject destroyedVersion;
    public float DestroySpeed;

    float speed;
    bool SpeedIsThere;
    bool SpawnAndDestroy = false;
    private void Start()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (SpeedIsThere || (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > DestroySpeed && collision.gameObject.layer == 8/*collision.collider.gameObject.layer == LayerMask.NameToLayer("Grab")*/ ))
        {
            
            SpawnAndDestroy = true;   
        }
    }

    private void FixedUpdate()
    {
        speed = this.GetComponent<Rigidbody>().velocity.magnitude;
        if (speed > DestroySpeed)
        { SpeedIsThere = true; }
        else { SpeedIsThere = false; }

        if (SpawnAndDestroy == true)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            SpawnAndDestroy = false;
        }
    }
}
