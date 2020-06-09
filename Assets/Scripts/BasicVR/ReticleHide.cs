using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleHide : MonoBehaviour
{
    public GameObject Recticle;
    public GameObject Laser;

    void Update()
    {
        if (Laser.activeInHierarchy == true)
        {
            Recticle.SetActive(true);
            Debug.Log("Tut");
        }
        else
        { Recticle.SetActive(false); }

    }
}