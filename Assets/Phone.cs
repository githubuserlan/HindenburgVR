using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{

    public AudioSource Anfang;


    public AudioSource Menschenlos;

    public AudioSource WoIstDietrich;

    public AudioSource SchatzCode;

    public AudioSource Murmel;

    public AudioSource Geschafft;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Phone")
        {
            Anfang.Play();
        }

        if (collision.gameObject.name == "Menschenlos")
        {
            Menschenlos.Play();
        }

        if (collision.gameObject.name == "TürSchloss")
        { WoIstDietrich.Play(); }

        if (collision.gameObject.name == "Rad1")
        {
            SchatzCode.Play();
        }
        if (collision.gameObject.name == "Labirynth")
        {
            //Murmel.Play();
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
