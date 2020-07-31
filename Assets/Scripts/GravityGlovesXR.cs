using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction;
using UnityEditor.Experimental.GraphView;
using UnityEngine.iOS;

public class GravityGlovesXR : MonoBehaviour
{

    public XRController leftRay;
    public XRController rightRay;
    public InputHelpers.Button activationButton; //ActivationButton
    public float Power;  //Power wie sehr das Objekt herfliegt
    public float interactionRayLength; //Länge des Rays für die Interaktion
    Vector3 rotationControllerBuffer;

    public Material materialOfObject;
    public Material targetMaterial;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Basic Ray Code
        Vector3 playerPosition = rightRay.transform.position;
        Vector3 fowardDirection = rightRay.transform.forward;
        Ray interactionRay = new Ray(playerPosition, fowardDirection);
        RaycastHit interactionRayHit;
        Vector3 interactionRayEndpoint = fowardDirection * interactionRayLength;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);


        bool hitfound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        //if it hit something
        if (hitfound)
        {
            //nenne Hit Object
            GameObject hitGameobject = interactionRayHit.transform.gameObject;
            //check if Grabable Item
            if (hitGameobject.layer == LayerMask.NameToLayer("Grab"))
            {
                //save current material
                if (materialOfObject != hitGameobject.GetComponent<Renderer>().material) { materialOfObject = hitGameobject.GetComponent<Renderer>().material; }

                //check if activationbutton is active
                //if ()
                //{
                //change color of hitobject
                if (hitGameobject.GetComponent<Renderer>() != null)
                {
                    hitGameobject.GetComponent<Renderer>().material = targetMaterial;
                }
                //save Rotation of controller
                    rotationControllerBuffer = rightRay.transform.eulerAngles;
                    //check for controller flip
                    //if (rightRay.transform.eulerAngles.x >= rotationControllerBuffer.x + 45)
                    //{
                        //move object to player with force
                        Rigidbody hitRigidBody = hitGameobject.gameObject.GetComponent<Rigidbody>();
                        hitRigidBody.AddForce(transform.forward * -0.5f * Power, ForceMode.Impulse);
                    //}
                    //else
                    //{
                        rotationControllerBuffer = new Vector3(0, 0, 0);
                    //}
                //}
                //else { hitGameobject.GetComponent<Renderer>().material = materialOfObject; } //if Object isnt hit by Ray anymore, get color back
            }
        }
    }
}
