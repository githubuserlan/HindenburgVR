using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class Numberlock : MonoBehaviour
{
   static public GameObject N1;
   static public GameObject N2;
   static public GameObject N3;
   static public GameObject N4;
    float N1_Rot;
    //float N2_Rot;
    //float N3_Rot;
    //float N4_Rot;


    public GameObject LeftHand;
    public GameObject RightHand;
    GameObject LeftHitObject;
    GameObject RightHitObject;
    bool LeftGrip;
    bool RightGrip;

    public GameObject ChildHandNull;
    public GameObject spawnObject;
    Vector3 handRot;
    Vector3 savedPosition;
    public bool spawnedHands = false;
    public GameObject Camera;
    Vector3 zeroVector3;

    public GameObject HandTranslatorL;
    public GameObject HandTranslatorR;

    // Start is called before the first frame update
    void Start()
    {
        N1_Rot = this.transform.localEulerAngles.x;
        LeftHitObject = LeftHand.GetComponent<Inventory>().HitObject;
        RightHitObject = RightHand.GetComponent<Inventory>().HitObject;
        LeftGrip = LeftHand.GetComponent<Inventory>().gripButtonAction;
        RightGrip = RightHand.GetComponent<Inventory>().gripButtonAction;
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
        if (N1_Rot > 360)
        { N1_Rot = 1; }
        if (N1_Rot < 0)
        {
            N1_Rot = 359;
        }
        if (LeftHitObject == this.gameObject)
        {
            HandSpawn(LeftHand, LeftGrip, HandTranslatorL);
        }
        if (RightGrip == this.gameObject)
        { HandSpawn(RightHand, RightGrip, HandTranslatorR); }

    }

    void HandSpawn(GameObject Hand, bool Grip, GameObject Translator)
    {
        if (Grip == true)
        {
            if (spawnedHands == false)
            {
                Hand.transform.position = ChildHandNull.transform.position;
                spawnObject = Instantiate(Translator);
                spawnedHands = true;
            }
            Hand.GetComponent<XRController>().enabled = false;
            handRot.x = spawnObject.transform.eulerAngles.y + 90;
            savedPosition = Hand.transform.position;
            Hand.transform.parent = ChildHandNull.transform;
            this.transform.localEulerAngles = new Vector3(handRot.x, -90, 90);
        }
        else
        {
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
        if (N1_Rot < 360 && N1_Rot > 330)
        {
            N1_Rot = 350;//8  
            if (N1_Rot < 330 && N1_Rot > 290) N1_Rot = 310;  //9
            if (N1_Rot < 290 && N1_Rot > 250) N1_Rot = 270;  //1
            if (N1_Rot < 250 && N1_Rot > 210) N1_Rot = 230;  //2
            if (N1_Rot < 210 && N1_Rot > 170) N1_Rot = 190;  //3
            if (N1_Rot < 170 && N1_Rot > 130) N1_Rot = 150;  //4
            if (N1_Rot < 130 && N1_Rot > 90) N1_Rot = 110;   //5
            if (N1_Rot < 90 && N1_Rot > 50) N1_Rot = 70;     //6
            if (N1_Rot < 50 && N1_Rot > 10) N1_Rot = 30;     //7
            if (N1_Rot < 10 && N1_Rot > 0) N1_Rot = 350;     //8
                                      this.transform.localEulerAngles = new Vector3(N1_Rot, -90f, 90f);


            if (N1.transform.localEulerAngles.x == 270 && N2.transform.localEulerAngles.x == 310 && N3.transform.localEulerAngles.x == 190 && N4.transform.localEulerAngles.x == 30)
            {
                //soundcomplete
                //schatztruhe öffnet
                this.transform.parent.gameObject.AddComponent<Rigidbody>();
            }
                //Code ist 1937
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
}