using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleHide : MonoBehaviour
{

    /// <summary>
    /// Dieses Script ist für das darstellen und verstecken des Reticle;
    /// </summary>
    public GameObject Recticle;
    public GameObject Laser;

    void Update()
    {
        if (Laser.activeInHierarchy == true)
        {
            Recticle.SetActive(true);
        }
        else
        { Recticle.SetActive(false); }

    }
}