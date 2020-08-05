﻿using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class Doorweel : MonoBehaviour
{
    // Start is called before the first frame update
    bool snaped = false;
    public GameObject WeelBox;
    Vector3 Aposition;
    float desiredRotz;
    public GameObject LeftHand;
    public GameObject RightHand;
    bool LeftHandIn;
    bool RightHandIn;
    Vector3 Rot;
    bool opened = false;


    public AudioSource RiddleDone;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == WeelBox)
        {
            this.transform.position = WeelBox.transform.position;
            Aposition = WeelBox.transform.position;
            WeelBox.SetActive(false);
            snaped = true;
            //Hinge = this.gameObject.AddComponent<HingeJoint>();
            //this.GetComponent<HingeJoint>().useSpring = true;
            //this.GetComponent<HingeJoint>().useLimits = true;
            //Hinge.axis = new Vector3(0, 0, 1);
            Debug.Log("trigger");
            this.transform.eulerAngles = new Vector3(0, 0, 270);
            this.gameObject.layer = 0;
            this.GetComponent<Rigidbody>().isKinematic = true;
            RiddleDone.Play();
        }

        if (collision.gameObject == LeftHand)
        { LeftHandIn = true; }
        if (collision.gameObject == RightHand)
        { RightHandIn = true; }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == LeftHand)
        { LeftHandIn = false; }
        if (collision.gameObject == RightHand)
        { RightHandIn = false; }
    }

    private void Update()
    {
        if (snaped == true)
        {
            this.gameObject.transform.position = Aposition;
            desiredRotz = this.transform.localEulerAngles.z;
            if (this.transform.localEulerAngles.x != 0 || this.transform.localEulerAngles.y != 0)
            {
                this.transform.localEulerAngles = new Vector3(0, 0, desiredRotz);
            }

            if (this.transform.localEulerAngles.z > 270)
            { this.transform.localEulerAngles = new Vector3(0, 0, 270f); }
            if (this.transform.localEulerAngles.z < 90)
            { this.transform.localEulerAngles = new Vector3(0, 0, 90f); }


            if (this.transform.localEulerAngles.z <= 95 && opened==false)
            { openDoor(); opened = true; }
        }
    }
    void openDoor()
    {
        //openDoor
        Debug.Log("Opens");
    }
    private void Start()
    {
    }

}
