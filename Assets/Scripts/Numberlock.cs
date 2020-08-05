using Boo.Lang;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class Numberlock : MonoBehaviour
{
    static public GameObject N1;
    static public GameObject N2;
    static public GameObject N3;
    static public GameObject N4;
    public float N1_Rot;
    //float N2_Rot;
    //float N3_Rot;
    //float N4_Rot;


    public GameObject LeftHand;
    public GameObject RightHand;
    GameObject LeftHitObject;
    GameObject RightHitObject;
    public bool LeftGrip;
    public bool RightGrip;

    //public GameObject ChildHandNull;
    public GameObject spawnObject;
    Vector3 handRot;
    Vector3 savedPosition;
    public bool spawnedHands = false;
    public GameObject Camera;
    Vector3 zeroVector3;

    public GameObject HandTranslatorL;
    public GameObject HandTranslatorR;
    public GameObject Parent;

    public float SavedRot;
    public float StartRot;

    public GameObject Null;

    public bool DiamomdIn;

    public AudioSource RiddleDone;
    public AudioSource Click;

    public GameObject ChestTopAnchor;
    public GameObject Phone;

    // Start is called before the first frame update
    void Start()
    {
        zeroVector3 = new Vector3(0, 0, 0);
        switch (this.gameObject.name)
        {
            case "Rad1":
                N1 = this.gameObject;
                break;
            case "Rad2":
                N2 = this.gameObject;
                break;
            case "Rad3":
                N3 = this.gameObject;
                break;
            case "Rad4":
                N4 = this.gameObject;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        N1_Rot = this.transform.localEulerAngles.y;
        LeftGrip = LeftHand.GetComponent<Inventory>().gripButtonAction;
        RightGrip = RightHand.GetComponent<Inventory>().gripButtonAction;
        LeftHitObject = LeftHand.GetComponent<Inventory>().HitObject;
        RightHitObject = RightHand.GetComponent<Inventory>().HitObject;

        if (N1_Rot > 360)
        { N1_Rot = 1; }
        if (N1_Rot < 0)
        {
            N1_Rot = 359;
        }
        //Debug.Log(this.transform.localEulerAngles);
        if (LeftHitObject == this.gameObject)
        {
            HandSpawn1(LeftHand, LeftGrip, HandTranslatorL, this.gameObject);
            //Debug.Log("StartLeft");
        }
        if (RightHitObject == this.gameObject)
        {
            HandSpawn1(RightHand, RightGrip, HandTranslatorR, this.gameObject);
            //Debug.Log("StartRight");
        }

    }

    void HandSpawn1(GameObject HandL, bool GripL, GameObject Translator, GameObject ChildHandNull)
    {
        if (GripL == true)
        {
            //Debug.Log("Grip of " + Hand + " is true");
            if (spawnedHands == false)
            {
                HandL.transform.position = ChildHandNull.transform.position;
                spawnObject = Instantiate(Translator);
                SavedRot = spawnObject.transform.localEulerAngles.x;
                spawnedHands = true;
            }
        }
    }
    void LateUpdate()
    {
        if (LeftHitObject == this.gameObject)
        {
            HandSpawn2(LeftHand, LeftGrip, this.gameObject);
            //Debug.Log("StartLeft");
        }
        if (RightHitObject == this.gameObject)
        {
            HandSpawn2(RightHand, RightGrip, this.gameObject);
            //Debug.Log("StartRight");
        }
        //if (this.transform.localEulerAngles.y % 40 == 0 && Click.enabled == true)
        //{
        //    Click.Play();
        //    Debug.Log("Click");
        //    Click.enabled = false;
        //}

        if (N1.transform.localEulerAngles.y == 200 && N2.transform.localEulerAngles.y == 160 && N3.transform.localEulerAngles.y == 280 && N4.transform.localEulerAngles.y == 80 && DiamomdIn == true)
        {
            //soundcomplete
            //schatztruhe öffnet
            //N1.transform.parent.gameObject.AddComponent<Rigidbody>();
            //N2.transform.parent.gameObject.AddComponent<Rigidbody>();
            //N3.transform.parent.gameObject.AddComponent<Rigidbody>();
            //N4.transform.parent.gameObject.AddComponent<Rigidbody>();
            //DiamomdIn = false;
            RiddleDone.Play();
            if (ChestTopAnchor.GetComponent<Animation>().isPlaying == false)
            {
                ChestTopAnchor.GetComponent<Animation>().Play();
            }
            Debug.Log("Lock geöffnet");
            if (Phone != null)
            {
                Phone.GetComponent<Phone>().Geschafft.Play();
            }
            Destroy(this.GetComponent<Numberlock>());
        }
        //Code ist 1937

    }
    void HandSpawn2(GameObject Hand, bool Grip, GameObject ChildHandNullL)
    {
        if (Grip == true)
        {
            //Click.enabled = true;
            Hand.GetComponent<XRController>().enabled = false;
            handRot.y = spawnObject.transform.localEulerAngles.x;
            savedPosition = Hand.transform.position;
            Hand.transform.parent = ChildHandNullL.transform;
            this.transform.localEulerAngles = new Vector3(0, StartRot + (handRot.y * 2) - (SavedRot * 2), 0);
        }
        else
        {
            //Click.enabled = false;
            StartRot = this.transform.localEulerAngles.y;
            SavedRot = 0;
            if (spawnObject != null)
            {
                Hand.GetComponent<XRController>().enabled = true;
                Destroy(spawnObject);
                spawnedHands = false;
                Hand.transform.parent = Camera.transform;
                if (savedPosition != zeroVector3)
                {
                    Hand.transform.position = savedPosition;
                    savedPosition = zeroVector3;
                }
            }
            CheckRotationLock();
        }
    }

    void CheckRotationLock()
    {
        //N1_Rot = N1_Rot + 10f;
        if (N1_Rot < 20 && N1_Rot > 0) { N1_Rot = 0; Debug.Log("Set to 5"); }
        if (N1_Rot < 60 && N1_Rot > 20) { N1_Rot = 40; Debug.Log("Set to 6"); }
        if (N1_Rot < 100 && N1_Rot > 60) { N1_Rot = 80; Debug.Log("Set to 7"); }
        if (N1_Rot < 140 && N1_Rot > 100) { N1_Rot = 120; Debug.Log("Set to 8"); }
        if (N1_Rot < 180 && N1_Rot > 140) { N1_Rot = 160; Debug.Log("Set to 9"); }
        if (N1_Rot < 220 && N1_Rot > 180) { N1_Rot = 200; Debug.Log("Set to 1"); }
        if (N1_Rot < 260 && N1_Rot > 220) { N1_Rot = 240; Debug.Log("Set to 2"); }
        if (N1_Rot < 300 && N1_Rot > 260) { N1_Rot = 280; Debug.Log("Set to 3"); }
        if (N1_Rot < 340 && N1_Rot > 300) { N1_Rot = 320; Debug.Log("Set to 4"); }
        if (N1_Rot < 360 && N1_Rot > 340) { N1_Rot = 360; Debug.Log("Set to 5"); }
        this.transform.localEulerAngles = new Vector3(0, N1_Rot, 0);
    }

    /*        
    8 = 350   10 
    9 = 310   330
    1 = 270   290
    2 = 230   250
    3 = 190   210
    4 = 150   170
    5 = 110   130
    6 = 70    90
    7 = 30    50
              10



    */
}