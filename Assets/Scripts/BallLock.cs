using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLock : MonoBehaviour
{
    // Start is called before the first frame update

    // Start is called before the first frame update
    bool snaped = false;
    public GameObject BallBox;
    Vector3 Aposition;
    float desiredRotz;
    bool LeftHandIn;
    bool RightHandIn;
    Vector3 Rot;
    public GameObject Rad;
    float speed;
    bool opened = false;
    public float pitchex;

    public bool speedForStopSound;

    public AudioSource rollingBall;
    public AudioSource stoppingBall;

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == BallBox)
        {
            Debug.Log("trigger");
            this.transform.position = BallBox.transform.position;
            Aposition = BallBox.transform.position;
            BallBox.GetComponent<Collider>().enabled = false;
            this.transform.eulerAngles = new Vector3(0, 0, 270);
            this.gameObject.layer = 0;
            Debug.Log("RIgidBody");
            this.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log(this.GetComponent<Rigidbody>().isKinematic);
            this.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log(this.GetComponent<Rigidbody>().useGravity);
            snaped = true;
            GameObject.Find("Rad1").GetComponent<Numberlock>().DiamomdIn = true;
        }

        //CollisionSound:
        if (collision.collider.gameObject.layer == 31)
        {
            if (speedForStopSound == true) { stoppingBall.volume = speed/2; stoppingBall.Play(); speedForStopSound = false; Debug.Log("Hit"); }
        }
        //Debug.Log(collision.collider.gameObject.layer);
    }
    private void LateUpdate()
    {
        if (rollingBall != null)
        {
            speed = this.GetComponent<Rigidbody>().velocity.magnitude;
            rollingBall.pitch = speed + pitchex;
            rollingBall.volume = speed *5;
            if (speed > 0.1)
            {
                speedForStopSound = true;
            }
            else { speedForStopSound = false; }
        }
        else
        { }
    }
}
