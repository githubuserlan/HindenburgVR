using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{

    public AudioSource Anfang;
    bool AnfangPlayed;

    public AudioSource Menschenlos;
    bool MenschenlosPlayed;
    public AudioSource WoIstDietrich;
    bool WoIstDietrichPlayed;
    public AudioSource SchatzCode;
    bool SchatzCodePlayed;
    public AudioSource Murmel;
    bool MurmelPlayed;
    public AudioSource Geschafft;
    bool GeschafftPlayed;


    private void OnTriggerEnter(Collider collision)



    {
        if (collision.gameObject.name == "Phone" && AnfangPlayed == false)
        {
            Anfang.Play();
            AnfangPlayed = true;
        }

        if (collision.gameObject.name == "Menschenlos" && MenschenlosPlayed == false)
        {
            Menschenlos.Play();
            MenschenlosPlayed = true;
        }

        if (collision.gameObject.name == "TürSchloss" && WoIstDietrichPlayed == false)
        {
            WoIstDietrich.Play();
            WoIstDietrichPlayed = true;
        }

        if (collision.gameObject.name == "Rad1"&&SchatzCodePlayed==false)
        {
            SchatzCode.Play();
            SchatzCodePlayed = true;
        }
        if (collision.gameObject.name == "Labirynth" && MurmelPlayed==false)
        {
            //Murmel.Play();
            MurmelPlayed = true;
        }

        //if(collision.gameObject.name=="PhoneGürtel")
        //{
        //    this.transform.position = collision.transform.position;
        //    this.GetComponent<Rigidbody>().isKinematic = true;
        //    PhoneGürtel = collision.gameObject;
        //    collision.gameObject.SetActive(false);
        //    Debug.Log("anGürtelRan");
        //}

    }

    private void Update()
    {
        //if (RightHand.GetComponent<Inventory>().HitObject == this.gameObject && RightHand.GetComponent<Inventory>().gripButtonAction == true && PhoneGürtel!=null)
        //{
        //    this.GetComponent<Rigidbody>().isKinematic = false;
        //    PhoneGürtel.SetActive(true);
        //}
    }
}
