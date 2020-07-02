using System;
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

    public bool spawnedHands =false;

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
    void FixedUpdate()
    {
        if (grabHand.GetComponent<Inventory>().HitObject == this.gameObject)
        {
            dietrichgrabed = true;
            Debug.Log("dietrichgrab = " + dietrichgrabed);
        }
        else { dietrichgrabed = false; }
    }
    private void LateUpdate()
    {

        if (dietrichgrabed == true && grabHand.GetComponent<Inventory>().gripButtonAction == true)
        {
            if (spawnedHands == false)
            {
                grabHand.transform.position = dietrich.transform.position;
                spawnObject = Instantiate(grabHand);
                spawnedHands = true;
                Destroy(spawnObject.transform.GetChild(1).gameObject);
                Debug.Log("Spawned a Hand");
            }
            grabHand.GetComponent<XRController>().enabled = false;
            handRot = spawnObject.transform.eulerAngles;
            Debug.Log("HandRotation is " + handRot);
        }
        else
        {
            if(spawnObject!=null)
            {
               for(int i =0; i<=spawnObject.transform.childCount; i++)
                {
                    spawnObject.transform.GetChild(0);
                    i--;
                }
                grabHand.GetComponent<XRController>().enabled = true;
                Destroy(spawnObject);
                spawnedHands = false;
                Debug.Log("Destroyed a Hand");
            }
        }
    }
}
