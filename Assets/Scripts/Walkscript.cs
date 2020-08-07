using UnityEngine;
using System.Collections;


public class Walkscript : MonoBehaviour
{

    // Use this for initialization
    public AudioSource Walk;
    CharacterController cc;
    float volume;public float N;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Walk.isPlaying == false)
        //{
            Walk.pitch = Random.Range(0.5f, 0.7f);
            volume = Random.Range(0.8f, 1f);
            if (volume > 1)
            { volume = 1; Walk.volume = 1; }
            else { Walk.volume = volume; }
            Walk.Play();
        //}
        Debug.Log(volume);
    }
}