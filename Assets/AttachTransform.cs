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

    // Start is called before the first frame update
    void Start()
    {
        Pivot = this.gameObject.transform.GetChild(0).gameObject;
        ObjectGrabed = this.GetComponent<Inventory>().HitObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectGrabed != null && ObjectGrabed.GetComponent<XRGrabInteractable>()!=null)
        {
            ObjectGrabed.GetComponent<XRGrabInteractable>().attachTransform = Pivot.transform;
        }
    }
}
