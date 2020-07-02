using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class inventory : MonoBehaviour
{
    // 
    /// <summary>
    /// Wenn Objekt in Inventar geht, dann soll
    /// 1. Objekt anderes Material erhalten
    /// 2. Bei loslassen objekt ins Inventar gehen
    /// 3. Falls Inventar voll ist, dann soll: UI erscheinen
    /// 4. Griff ins Inventar holt Objekt wieder raus
    /// </summary>
    public XRDirectInteractor interactor;
    Collider Collider;
    public GameObject GrabedObject;

    // Start is called before the first frame update
    void Start()
    {
        Collider = this.gameObject.GetComponent<Collider>();
    }

    //private void OnEnable()
    //{
    //    interactor.onSelectEnter.AddListener(Grabed);
    //    Debug.Log("Grab");
    //    GrabedObject = this.selectTarget.gameObject;

    //    Debug.Log(selectTarget);
    //    //Objects = XRBaseInteractor.GetValidTargets(List<XRBaseInteractable>);
    //}


    public XRBaseInteractable selectTarget { get; }

    //private void Grabed(XRBaseInteractable interactable)
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("Test");
        }
    }




    // Update is called once per frame
    void Update()
    {
        //Debug.Log(selectTarget.GetComponent<XRGrabInteractable>());
    }
}
