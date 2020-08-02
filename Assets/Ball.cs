using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15)
        {
            other.gameObject.AddComponent<XRGrabInteractable>().movementType = this.transform.parent.GetComponent<XRGrabInteractable>().movementType;
            other.gameObject.layer = 8;
            other.transform.parent = null;
            Debug.Log("Ball falling");
        }
    }
}
