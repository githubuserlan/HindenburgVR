using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class DietrichObject2 : MonoBehaviour
{
    private List<InputDevice> devices = new List<InputDevice>();


    public GameObject grabHand;
    public GameObject dietrich;
    Vector3 handRot;
    bool dietrichgrabed;
    public GameObject spawnObject;
    public GameObject HandTranslatorR;
    Vector3 savedPosition;
    Vector3 zeroVector3;
    public GameObject Camera;
    public GameObject Pivot;
    public GameObject drehgelenk;


    public bool Level1 = false;
    public bool Level2 = false;
    public bool Level3 = false;

    public bool triggerLevel1;

    public float minRot;
    public float maxRot;

    public GameObject ChildHandNull;

    public AudioSource gotRight;
    public AudioSource levelDone;

    public bool spawnedHands = false;

    void Update()
    {
        Level1 = dietrich.GetComponent<SchlossKnacken>().triggerLevel1;
        Level2 = dietrich.GetComponent<SchlossKnacken>().triggerLevel2;
        Level3 = dietrich.GetComponent<SchlossKnacken>().triggerLevel3;
        if (grabHand.GetComponent<Inventory>().HitObject == this.gameObject)
        {
            dietrichgrabed = true;
        }
        else { dietrichgrabed = false; }

        if (dietrichgrabed == true && grabHand.GetComponent<Inventory>().triggerButtonAction == true)
        {
            if (spawnedHands == false)
            {
                grabHand.transform.position = ChildHandNull.transform.position;
                spawnObject = Instantiate(HandTranslatorR);
                spawnedHands = true;
            }
            grabHand.GetComponent<XRController>().enabled = false;
            handRot.y = spawnObject.transform.eulerAngles.y;
            savedPosition = grabHand.transform.position;
            grabHand.transform.parent = ChildHandNull.transform;
            drehgelenk.transform.eulerAngles = new Vector3(0, handRot.y, 0);
        }
        else
        {
            if (spawnObject != null)
            {
                grabHand.GetComponent<XRController>().enabled = true;
                Destroy(spawnObject);
                spawnedHands = false;
                grabHand.transform.parent = Camera.transform;
                if (savedPosition != zeroVector3)
                {
                    grabHand.transform.position = savedPosition;
                    savedPosition = zeroVector3;
                }
            }
        }


        if(Level1==true && drehgelenk.transform.eulerAngles.y == 60)
        {
            levelDone.Play();
            dietrich.GetComponent<SchlossKnacken>().Level1 = true;
        }
        if (Level2 == true && drehgelenk.transform.eulerAngles.y == 30)
        {
            dietrich.GetComponent<SchlossKnacken>().Level1 = true;
        }
        if (Level3 == true && drehgelenk.transform.eulerAngles.y == 0)
        {
            dietrich.GetComponent<SchlossKnacken>().Level1 = true;
        }


        //Vector3 Rot = drehgelenk.transform.eulerAngles;
        //if (Level1 == false || Level2 == false || Level3 == false)
        //{
        //    drehgelenk.transform.eulerAngles = Rot;
        //}

        if (dietrich.GetComponent<SchlossKnacken>().Level1 == false && drehgelenk.transform.eulerAngles.y <= 80)
        {
            drehgelenk.transform.eulerAngles = new Vector3(0, 80, 0);
        }
        if (dietrich.GetComponent<SchlossKnacken>().Level2 == false && drehgelenk.transform.eulerAngles.y <= 40)
        {
            drehgelenk.transform.eulerAngles = new Vector3(0, 40, 0);
        }
        if (dietrich.GetComponent<SchlossKnacken>().Level3 == false && drehgelenk.transform.eulerAngles.y <= 10)
        {
            drehgelenk.transform.eulerAngles = new Vector3(0, 10, 0);
        }
    }
}