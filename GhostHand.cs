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
        FakeHandTransform.position = RealHandTrans.position;
        FakeHandTransform.rotation = RealHandTrans.rotation;
        FakeHand.SetActive(true);
        Debug.Log("IsGhist");
    }
    private void OnTriggerExit(Collider other)
    {
        FakeHand.SetActive(false);
        Debug.Log("NoGhost");
    }
}
