using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleHide : MonoBehaviour
{
    public GameObject ScriptHolder;
    public GameObject Reticle;
    // Start is called before the first frame update
    void Start()
    {
        ScriptHolder = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ScriptHolder.active)
        { Reticle.SetActive(false); }
        else { 
            Reticle.SetActive(true); }
    }
}
