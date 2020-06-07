using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GhostHand : MonoBehaviour
{
    public GameObject FakeHand;
    Transform RealHandTrans;
    Transform FakeHandTransform;
    bool IsGhost;
    // Start is called before the first frame update
    void Start()
    {
        RealHandTrans = this.gameObject.transform;
        FakeHandTransform = FakeHand.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Grab"))
        {
            FakeHandTransform.position = RealHandTrans.position;
            FakeHandTransform.eulerAngles = RealHandTrans.eulerAngles;
            FakeHand.SetActive(true);
            Debug.Log("IsGhost");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        FakeHand.SetActive(false);
        Debug.Log("NoGhost");
    }
}
