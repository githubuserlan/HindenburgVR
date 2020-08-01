using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachTransform : MonoBehaviour
{
    XRGrabInteractable XRGrab;
    GameObject ObjectGrabed;
    //public XRBaseInteractable GrabedObject;
    Transform transformPos;
    public GameObject Pivot;
    public GameObject LeftHand;
    public GameObject LeftHandPivot;
    public GameObject RightHand;
    public GameObject RightHandPivot;

    // Start is called before the first frame update
    void Start()
    {
        LeftHandPivot = LeftHand.transform.GetChild(0).gameObject;
        RightHandPivot = RightHand.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ObjectGrabed = this.GetComponent<Inventory>().HitObject;
        if (ObjectGrabed != null && this.GetComponent<Inventory>().gripButtonAction!=true)
        {
            ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = this.gameObject.transform.GetChild(0).gameObject.transform;
        }
            if (LeftHand.GetComponent<Inventory>().HitObject == RightHand.GetComponent<Inventory>().HitObject && LeftHand.GetComponent<Inventory>().gripButtonAction == true)
            {
                ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = RightHandPivot.transform;
            }
            if (RightHand.GetComponent<Inventory>().HitObject == LeftHand.GetComponent<Inventory>().HitObject && RightHand.GetComponent<Inventory>().gripButtonAction == true)
            {
                ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = LeftHandPivot.transform;
            }

    }
}