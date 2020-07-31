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
    public GameObject RightHand;

    // Start is called before the first frame update
    void Start()
    {
        Pivot = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectGrabed = this.GetComponent<Inventory>().HitObject;
        if (ObjectGrabed != null && ObjectGrabed.GetComponent<XRGrabInteractable>()!=null)
        {
            ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = Pivot.transform;
            if(RightHand.gameObject.GetComponent<Inventory>().HitObject == RightHand.gameObject.GetComponent<Inventory>().HitObject && LeftHand.gameObject.GetComponent<Inventory>().gripButtonAction==true)
            {
                Pivot = RightHand.gameObject.transform.GetChild(0).gameObject;
            }
            else if (RightHand.gameObject.GetComponent<Inventory>().HitObject == RightHand.gameObject.GetComponent<Inventory>().HitObject && RightHand.gameObject.GetComponent<Inventory>().gripButtonAction == true)
            { Pivot = LeftHand.gameObject.transform.GetChild(0).gameObject; }
            else { Pivot = this.gameObject.transform.GetChild(0).gameObject; }


        }
    }
}
