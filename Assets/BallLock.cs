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
    bool opened = false;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lock-Collision")
        {
            this.transform.position = BallBox.transform.position;
            Aposition = BallBox.transform.position;
            BallBox.SetActive(false);
            Debug.Log("trigger");
            this.transform.eulerAngles = new Vector3(0, 0, 270);
            this.gameObject.layer = 0;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
