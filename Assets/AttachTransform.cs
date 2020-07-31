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
        Pivot = this.gameObject.transform.GetChild(0).gameObject;
        LeftHandPivot = LeftHand.transform.GetChild(0).gameObject;
        RightHandPivot = RightHand.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectGrabed = this.GetComponent<Inventory>().HitObject;
        if (ObjectGrabed != null)
        {
            ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = Pivot.transform;
        }
        if (LeftHand.GetComponent<Inventory>().HitObject == RightHand.GetComponent<Inventory>().HitObject && LeftHand.GetComponent<Inventory>().gripButtonAction == true)
        {
            ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = RightHandPivot.transform;
        }
        else if (RightHand.GetComponent<Inventory>().HitObject == LeftHand.GetComponent<Inventory>().HitObject && RightHand.GetComponent<Inventory>().gripButtonAction == true)
        {
            ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = LeftHandPivot.transform;
        }


    }
}