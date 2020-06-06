using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class locomotionController : MonoBehaviour
{
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThresholt = 0.1f;



    // Update is called once per frame
    void Update()
    {
        if(leftTeleportRay)
        {

            Wait();
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
        }
        if (rightTeleportRay)
        {
            Wait();
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay));
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }
    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThresholt);
        return isActivated;
    }
}
