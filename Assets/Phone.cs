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


    public GameObject Türknauf;

    // Update is called once per frame
    private void Start()
    {
        Anfang.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Menschenlos") ;
        {
            Menschenlos.Play();
        }

        if (collision.gameObject == Türknauf)
        { WoIstDietrich.Play(); }

        if (collision.gameObject.name == "Rad1")
        {
            SchatzCode.Play();
        }
        if (collision.gameObject.name == "Labirynth")
        {
            Murmel.Play();
        }
        if(collision.gameObject.name=="Schloss")
        {
            Geschafft.Play();
        }
    }
}
