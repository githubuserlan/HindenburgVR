using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

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
    public bool opened = false;
    public GameObject PivotRad;

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
            this.transform.localEulerAngles = new Vector3(0, -90, 11);
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
        if (snaped == true &&opened==false)
        {
            this.gameObject.transform.position = Aposition;
            desiredRotz = this.transform.localEulerAngles.z;
            this.GetComponent<XRGrabInteractable>().trackPosition = false;

            this.transform.localEulerAngles = new Vector3(0, -90, desiredRotz);
            Debug.Log(desiredRotz);
            if (desiredRotz < 170 && opened==false)
            { openDoor(); opened = true; }

            //if (this.transform.localEulerAngles.z < 10)
            //{
            //    desiredRotz = 11f;
            //    this.transform.localEulerAngles = new Vector3(0, -90, desiredRotz); Debug.Log("Force Smaller Than 10");
            //}
            //if (this.transform.localEulerAngles.z > 175)
            //{ desiredRotz = 174; this.transform.localEulerAngles = new Vector3(0, -90, desiredRotz); Debug.Log("Force Bigger Than 180"); }
        }
    }
    void openDoor()
    {
        this.transform.parent = PivotRad.transform;
        PivotRad.GetComponent<Animator>().Play("OpenDoorRing");
        //openDoor
        Debug.Log("Opens");
    }
    private void Start()
    {
    }

}
