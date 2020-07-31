using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("HitTrigger");
        if (collision.gameObject.layer == 15)
        {
            collision.gameObject.layer = 8;
            Debug.Log("BallLayerChange");
            collision.gameObject.AddComponent<XRGrabInteractable>();
            collision.gameObject.GetComponent<XRGrabInteractable>().movementType = this.gameObject.transform.parent.gameObject.GetComponent<XRGrabInteractable>().movementType;
            collision.gameObject.transform.parent = null;
            this.gameObject.transform.parent.GetComponent<XRGrabInteractable>().colliders[1] = null;
        }
    }
}
