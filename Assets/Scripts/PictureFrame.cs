using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PictureFrame : MonoBehaviour
{

    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject BackFrame;
    bool backframeObject; //identify which object script is on, false for mainborder, true for backframe
    public static bool GrabedObject; //is frame grabbed?
    bool added;
    public GameObject Bilderrahmen;
    public bool BackFrameGrabedOnce;

    public AudioSource RiddleDone;

    // Start is called before the first frame update
    void Start()
    {


        if (BackFrame == this.gameObject)
        {
            backframeObject = true;
        }
        else backframeObject = false;

        if (backframeObject == true)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        {if(collision.gameObject.layer==12)
            {
                this.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    private void Update()
    {  //IF Frame is grabed, then 
        if (LeftHand.GetComponent<Inventory>().HitObject == this.gameObject && LeftHand.GetComponent<Inventory>().gripButtonAction == true && backframeObject == false)
        {
            GrabedFrame(1);
        }
        if (RightHand.GetComponent<Inventory>().HitObject == this.gameObject == this.gameObject && RightHand.GetComponent<Inventory>().gripButtonAction == true && backframeObject == false)
        {
            GrabedFrame(2);
        }

        //if (BackFrame.GetComponent<Collider>().enabled = true && RightHandHit != this.gameObject || LeftHandHit != this.gameObject)
        //{
        //    //BackFrame.GetComponent<Collider>().enabled = false;
        //    GrabedObject = false;
        //}
        //Backframe
        if (LeftHand.GetComponent<Inventory>().triggerButtonAction == true && backframeObject == true && GrabedObject == true)
        {
            BackframeMethod(LeftHand);
        }
        if (RightHand.GetComponent<Inventory>().triggerButtonAction == true && backframeObject == true && GrabedObject == true)
        {
            BackframeMethod(RightHand);
        }



        if(BackFrameGrabedOnce==true)
        {
            Bilderrahmen.GetComponent<PictureFrame>().RiddleDone.Play();
            if (RightHand.GetComponent<Inventory>().triggerButtonAction == false && LeftHand.GetComponent<Inventory>().triggerButtonAction == false)
            {
                BackFrame.transform.parent = null;
                BackFrame.GetComponent<Rigidbody>().isKinematic = false;
                GameObject kid = BackFrame.transform.GetChild(0).gameObject;
                kid.transform.parent = Bilderrahmen.transform;
                BackFrame.transform.parent = kid.transform;
                Destroy(BackFrame.GetComponent<XRGrabInteractable>());
                foreach (var comp in gameObject.GetComponents<Component>())
                {
                    if (!(comp is Transform))
                    {
                        Destroy(comp);
                    }
                }

                kid.AddComponent<Rigidbody>();
                kid.AddComponent<BoxCollider>();
                kid.AddComponent<XRGrabInteractable>();
                BackFrameGrabedOnce = false;
                Destroy(this.GetComponent<PictureFrame>());
            }
        }
    }


    private void GrabedFrame(int Hand)  //then Backframe is grabable
    {
        if (added == false)
        {
            added = true;
            BackFrame.GetComponent<Collider>().enabled = true;
            BackFrame.AddComponent<XRGrabInteractable>();
            BackFrame.AddComponent<Rigidbody>();
            BackFrame.GetComponent<Rigidbody>().isKinematic = true;
            GrabedObject = true;
            Debug.Log("Grabed");
        }
    }

    private void BackframeMethod(GameObject Hand)
    {
        Debug.Log("Pinched with " + Hand);
        BackFrame.transform.parent = Hand.transform;
        BackFrameGrabedOnce = true;
    }


}
