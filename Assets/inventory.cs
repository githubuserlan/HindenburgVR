using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class inventory : MonoBehaviour
{

    public GameObject handObject = null;
    public XRDirectInteractor interactor = null;

    // 
    /// <summary>
    /// Wenn Objekt in Inventar geht, dann soll
    /// 1. Objekt anderes Material erhalten
    /// 2. Bei loslassen objekt ins Inventar gehen
    /// 3. Falls Inventar voll ist, dann soll: UI erscheinen
    /// 4. Griff ins Inventar holt Objekt wieder raus
    /// </summary>

    Collider Collider;

    // Start is called before the first frame update
    void Start()
    {
        Collider = this.gameObject.GetComponent<Collider>();
    }



    private void OnEnable()
    {
        interactor.onSelectEnter.AddListener(Grabed);
        Debug.Log("Grab");
    }
    private void OnDisable()
    {
     
    }

    private void Grabed(XRBaseInteractable interactable)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
