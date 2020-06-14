using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    /// <summary>
    /// Dieses Script ist für das zerstörren von Objekten
    /// DestroySpeed ist die Geschwindigkeit in m, ab der das Objekt zerstörrt wird
    /// DestroyedVersion ist das zerstörrte 3D Objekt (Prefab)
    /// </summary>

    public GameObject destroyedVersion;
    public float DestroySpeed;

    float speed;
    bool SpeedIsThere;
    bool SpawnAndDestroy = false;

    private void OnCollisionEnter(Collision collision)
    {
        //Check if Speed of Colliding Object is high enough
        if (SpeedIsThere || (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > DestroySpeed && collision.gameObject.layer == 8/*collision.collider.gameObject.layer == LayerMask.NameToLayer("Grab")*/ ))
        {
            //Lets destroy
            SpawnAndDestroy = true;   
        }
    }

    private void FixedUpdate()
    {
        speed = this.GetComponent<Rigidbody>().velocity.magnitude;
        if (speed > DestroySpeed)
        { SpeedIsThere = true; }
        else { SpeedIsThere = false; }


        //Is in FixedUpdate because else multiple DestroyedVersion can spawn
        if (SpawnAndDestroy == true)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
            SpawnAndDestroy = false;
        }
    }
}
