using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstept : MonoBehaviour
{
    CharacterController cc;
    AudioSource Stepaudio;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f && Stepaudio.isPlaying == false)
        {
            Stepaudio.volume = Random.Range(0.8f, 1);
            Stepaudio.pitch = Random.Range(0.8f, 1.1f);


            Stepaudio.Play();
        }
    }
}
