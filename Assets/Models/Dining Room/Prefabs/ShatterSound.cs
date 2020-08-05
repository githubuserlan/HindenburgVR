using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource broken = this.GetComponent<AudioSource>();
        float pitch = Random.Range(0.8f, 1.1f);
        //Debug.Log(pitch);
        broken.pitch = 1.5f;
        broken.Play();
    }
}
