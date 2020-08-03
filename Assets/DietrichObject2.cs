﻿using System.Collections;
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

    public bool Level1;
    public bool Level2;
    public bool Level3;

    public bool TriggerLevel1 = false;
    public bool TriggerLevel2 = false;
    public bool TriggerLevel3 = false;

    public float minRot;
    public float maxRot;

    public GameObject ChildHandNull;

    public AudioSource gotRight;
    public AudioSource levelDone;

    public bool spawnedHands = false;

    void Update()
    {
            TriggerLevel1 = dietrich.GetComponent<SchlossKnacken>().triggerLevel1;
            TriggerLevel2 = dietrich.GetComponent<SchlossKnacken>().triggerLevel2;
            TriggerLevel3 = dietrich.GetComponent<SchlossKnacken>().triggerLevel3;

            Level1 = dietrich.GetComponent<SchlossKnacken>().Level1;
            Level2 = dietrich.GetComponent<SchlossKnacken>().Level2;
            Level3 = dietrich.GetComponent<SchlossKnacken>().Level3;


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
                handRot.y = spawnObject.transform.eulerAngles.z+90;
                savedPosition = grabHand.transform.position;
                grabHand.transform.parent = ChildHandNull.transform;
                drehgelenk.transform.localEulerAngles = new Vector3(0, handRot.y, 0);
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

        if (Level3 != true)
        {
            if (TriggerLevel1 == true && drehgelenk.transform.localEulerAngles.y <= 80)
            {
                levelDone.Play();
                dietrich.GetComponent<SchlossKnacken>().Level1 = true;
                Debug.Log("Level1Clear");
            }
            if (TriggerLevel2 == true && drehgelenk.transform.localEulerAngles.y <= 45)
            {
                levelDone.Play();
                dietrich.GetComponent<SchlossKnacken>().Level2 = true;
                Debug.Log("Level2Clear");
            }
            if (TriggerLevel3 == true && drehgelenk.transform.localEulerAngles.y <= 15)
            {
                levelDone.Play();
                dietrich.GetComponent<SchlossKnacken>().Level3 = true;
                Debug.Log("Level3Clear");
            }


            //Vector3 Rot = drehgelenk.transform.eulerAngles;
            //if (Level1 == false || Level2 == false || Level3 == false)
            //{
            //    drehgelenk.transform.eulerAngles = Rot;
            //}

            if (drehgelenk.transform.localEulerAngles.y <= 80)
            {
                if (TriggerLevel1 == false && Level1 == false)
                {
                    drehgelenk.transform.localEulerAngles = new Vector3(0, 80, 0);
                }
            }
            if (drehgelenk.transform.localEulerAngles.y > 90)
            {
                drehgelenk.transform.localEulerAngles = new Vector3(0, 90, 0);
            }
            if (drehgelenk.transform.localEulerAngles.y <= 70)
            {
                if (TriggerLevel2 == false && Level2 == false)
                {
                    drehgelenk.transform.localEulerAngles = new Vector3(0, 70, 0);
                }
            }
            if (drehgelenk.transform.localEulerAngles.y <= 30)
            {
                if (TriggerLevel3 == false && Level3 == false)
                {
                    drehgelenk.transform.localEulerAngles = new Vector3(0, 30, 0);
                }
            }
        }
        else
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
    }
}