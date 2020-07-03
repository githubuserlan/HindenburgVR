﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class SchlossKnacken : MonoBehaviour
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



    public bool Level1 = false;
    public bool Level2 = false;
    public bool Level3 = false;

    public bool triggerLevel1;
    bool triggerLevel2;
        bool triggerLevel3;

    public float minRot;
    public float maxRot;

    public AudioSource gotRight;
    public AudioSource levelDone;

    public bool spawnedHands = false;

    // Start is called before the first frame update
    void Start()
    {
    }


    /// <summary>
    /// Prüfen ob beide Objekte berühren
    /// Stecke Objekte in das Schloss
    /// Greifen des Dietrichs, hand steckt in der Zeit am Dietrich
    /// oben und unten Movements, während sounds abspielen und vibriert. Vibration und sound helfen lösung
    /// bei richtigem Pick, A drücken
    /// eins tiefer und wiederholen, bis 3 Stifte erreicht
    /// </summary>

    // Update is called once per frame
    void Update()
    {
        if (grabHand.GetComponent<Inventory>().HitObject == this.gameObject)
        {
            dietrichgrabed = true;
        }
        else { dietrichgrabed = false; }

        if (dietrichgrabed == true && grabHand.GetComponent<Inventory>().gripButtonAction == true)
        {
            if (spawnedHands == false)
            {
                grabHand.transform.position = dietrich.transform.position;
                spawnObject = Instantiate(HandTranslatorR);
                spawnedHands = true; ;
            }
            grabHand.GetComponent<XRController>().enabled = false;
            handRot.x = spawnObject.transform.eulerAngles.x;
            savedPosition = grabHand.transform.position;
            grabHand.transform.parent = Pivot.transform;
            Pivot.transform.eulerAngles = new Vector3(handRot.x, 0, 0);
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


        if (dietrichgrabed == true)
        {
            if (Pivot.transform.localEulerAngles.x < 125 && Pivot.transform.eulerAngles.x > 132.5f && Level1 == false && Level2 == false && Level3 == false)
            {
                if (triggerLevel1 == false)
                {
                    Debug.Log("Click1");
                    gotRight.Play();
                    StartCoroutine(FirstClick());
                    triggerLevel1 = true;
                }
                
            }
            else
            { triggerLevel1 = false; }

            if (Pivot.transform.eulerAngles.x < 65 && Pivot.transform.eulerAngles.x > 55 && Level1 == true && Level2 == false && Level3 == false)
            {
                if (triggerLevel2 == false)
                {
                    Debug.Log("Click2");
                    gotRight.Play();
                    StartCoroutine(SecondClick());
                    triggerLevel2 = true;
                }
            }
            else
            { triggerLevel2 = false; }

            if (Pivot.transform.eulerAngles.x < 100 && Pivot.transform.eulerAngles.x > 110 && Level1 == true && Level2 == true)
            {
                if (triggerLevel3 == false)
                {
                    Debug.Log("Click3");
                    gotRight.Play();
                    StartCoroutine(ThirdClick());
                    triggerLevel3 = true;
                }
            }
            else
            { triggerLevel3 = false; }

            if (Level3 == true)
            {
                Debug.Log("Schloss geknackt");
            }
        }


        //if (Pivot.transform.localEulerAngles.x < minRot)
        //{
        //    Pivot.transform.localEulerAngles = new Vector3(minRot, 0, 0);
        //    Debug.Log("PlacedLow");
        //}

        //if (Pivot.transform.eulerAngles.x > maxRot)
        //{
        //    Pivot.transform.eulerAngles = new Vector3(maxRot, 0, 0);
        //    Debug.Log("PlacedHigh");
        //}

        //Debug.Log(Pivot.transform.eulerAngles.x);
    }

    IEnumerator FirstClick()
    {
        yield return new WaitForSeconds(1);
        if (Pivot.transform.localEulerAngles.x < 125 && Pivot.transform.eulerAngles.x > 132.5f)
        {
            Debug.Log("Level1 Done");
           yield return Level1 = true;
            levelDone.Play();
        }
    }

    IEnumerator SecondClick()
    {
        yield return new WaitForSeconds(2);
        if (Pivot.transform.eulerAngles.x < 65 && Pivot.transform.eulerAngles.x > 55)
        {
            Debug.Log("Level2 Done");
           yield return Level2 = true;
            levelDone.Play();
        }
    }

    IEnumerator ThirdClick()
    {
        yield return new WaitForSeconds(2);
        if (Pivot.transform.eulerAngles.x > 110 && Pivot.transform.eulerAngles.x < 100)
        {
            Debug.Log("Level3 Done");
            Level3 = true;
            levelDone.Play();
        }
    }
}
