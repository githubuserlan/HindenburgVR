using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gürtel : MonoBehaviour
{
    public Camera Camera;
    public float heightguertel;
    public float guertelDelay;
    // Start is called before the first frame update
    void Update()
    {
        float temp = Camera.gameObject.transform.position.y;
        this.gameObject.transform.position = Camera.gameObject.transform.position - new Vector3(0,temp -heightguertel, 0);
        float rotationy = this.gameObject.transform.eulerAngles.y;
        float rotationz = this.gameObject.transform.eulerAngles.z;
        Vector3 ObjectRot = new Vector3(0, rotationy, 0);
        this.gameObject.transform.eulerAngles = ObjectRot;
    }
}
