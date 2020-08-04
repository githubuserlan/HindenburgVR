using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private XRNode xrNode = XRNode.LeftHand;

    private List<InputDevice> devices = new List<InputDevice>();
    private InputDevice device;
    public bool gripButtonAction;
    public bool triggerButtonAction;
    bool takenSpawnedObject;
    static public GameObject leftInventoryPlace;
    static public GameObject rightInventoryPlace;
    public List<GameObject> preFabInventoryItems;
    public string ObjectName;
    Vector3 ObjectScale;

    public GameObject leftBag;
    public GameObject rightBag;

    public GameObject spawnObject;
    public bool needToLeave;
    public GameObject Dietrich;
    public GameObject andererDietrich;
    public GameObject MovementTypeKinematic;
    public GameObject MovementTypeVelocity;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        device = devices.FirstOrDefault();

    }

    void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
    }

    private void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        if (device.TryGetFeatureValue(CommonUsages.gripButton, out gripButtonAction) && gripButtonAction)
        {
            gripButtonAction = true;
        }

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonAction) && triggerButtonAction)
        {
            triggerButtonAction = true;
        }


        if (takenSpawnedObject == true)
        {
            if (spawnObject != null)
            {
                spawnObject.GetComponent<Rigidbody>().isKinematic = false; //aktiviere gravitation
                spawnObject.transform.parent = null; //ist kein child der Tasche mehr
                //StartCoroutine(ExampleCoroutine());
                spawnObject.transform.localScale = ObjectScale; //skalierung wird wieder zurück gestellt, wie es vor einlegen in die Tasche war.
            }
        }
    }

    public GameObject HitObject;

    private void OnTriggerEnter(Collider collider)
    {
        //Kontakt mit grabable Objekten
        if (collider.gameObject.layer == 8) //ist es ein grabable Item?
            if (gripButtonAction == false)
            {
                HitObject = collider.gameObject; //wird gespeichert als HitObject;
                ObjectName = HitObject.name;  //Speichern des Name des OBjects
                if (this.name == "RightHand Controller" && HitObject == Dietrich)
                {
                    HitObject = andererDietrich;
                }
                if (this.name == "LeftHand Controller" && HitObject == andererDietrich)
                {
                    HitObject = Dietrich;
                }
            }


        //Objekt ins Inventar legen:
        if (collider.gameObject.layer == 13) //Wenn Hand mit einer Tasche collided
        {
            takenSpawnedObject = false;
            if (rightInventoryPlace == null && HitObject != null && collider.name== "RightBag") // und die Tasche leer ist sowie man hat etwas in der Hand
            {
                for (int i = 0; i < preFabInventoryItems.Count; i++) //suche nach gegriffenem Objekt in List
                {
                    if (preFabInventoryItems[i].name == ObjectName) //suche nach Prefab in der Liste anhand des Namens
                    {
                        rightInventoryPlace = preFabInventoryItems[i]; //Inventarspeicherslot für die rechte Tasche
                        ObjectScale = HitObject.transform.localScale; //ich speichere die originale skalierung des Objekts (um das Objekt in die korrekte skalierung später zu bringen) 
                        Destroy(HitObject); //Objekt wird zerstörrt
                        HitObject = null; // kein Objekt mehr in der Hand
                        needToLeave = true;
                        Debug.Log("Destory");
                        break;
                    }
                }
            }

            if (rightInventoryPlace == null && HitObject != null && collider.name == "LeftBag") // und die Tasche leer ist sowie man hat etwas in der Hand
            {
                for (int i = 0; i < preFabInventoryItems.Count; i++) //suche nach gegriffenem Objekt in List
                {
                    if (preFabInventoryItems[i].name == ObjectName) //suche nach Prefab in der Liste anhand des Namens
                    {
                        leftInventoryPlace = preFabInventoryItems[i]; //Inventarspeicherslot für die rechte Tasche
                        ObjectScale = HitObject.transform.localScale; //ich speichere die originale skalierung des Objekts (um das Objekt in die korrekte skalierung später zu bringen) 
                        Destroy(HitObject); //Objekt wird zerstörrt
                        HitObject = null; // kein Objekt mehr in der Hand
                        needToLeave = true;
                        Debug.Log("Destory");
                        break;
                    }
                }
            }

            //greifen aus dem Inventar bzw das erscheinen des Objekts, wenn man mit der Hand zum Inventar geht
            if (HitObject == null && rightInventoryPlace != null && needToLeave == false) //wenn das Inventar bestückt ist und kein objekt gegriffen ist
            {
                if (rightBag.transform.childCount <= 1) // und maximal 1 Objekt als Child da ist (wegen bugs)
                {
                    spawnObject = Instantiate(rightInventoryPlace, rightBag.transform.position, transform.rotation); //soll Objekt erstellt werden
                    spawnObject.name = ObjectName; //es richtig benannt werden (falls man das Objekt wieder ins Invertar legen möchte)
                    spawnObject.transform.parent = rightBag.transform; // es schwebt an der Tasche, damit man es greifen kann
                    spawnObject.transform.position = rightBag.transform.position + new Vector3(0, 0, 0);  //Objekt wird über die Tasche gelegt.
                    spawnObject.transform.localScale = new Vector3(1f, 1f, 1f); // und ist während dem schweben kleiner
                    spawnObject.transform.localEulerAngles = new Vector3(0, 0, 0); // und richtig rotiert
                    spawnObject.GetComponent<Rigidbody>().isKinematic = true; // und die Gravity wird deaktiviert, damit das Objekt nicht direkt auf den Boden fällt
                    spawnObject.GetComponent<XRGrabInteractable>().movementType=MovementTypeKinematic.GetComponent<XRGrabInteractable>().movementType;
                }
            }
        }
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == 8)
            if (gripButtonAction == false)
            {
                HitObject = null;
            }
        if (collider.gameObject.layer == 13)
        {
            { // wenn das Objekt aus dem Inventar gezogen wird
                if (needToLeave == false && rightInventoryPlace != null && collider.name == "RightBag")
                {
                    if (gripButtonAction == true)
                    {
                        
                        rightInventoryPlace = null; //Inventar ist dann leer;
                        takenSpawnedObject = true;
                        Debug.Log("Done");
                        spawnObject.GetComponent<XRGrabInteractable>().movementType = MovementTypeVelocity.GetComponent<XRGrabInteractable>().movementType;
                    }
                }
            }

            { // wenn das Objekt aus dem Inventar gezogen wird
                if (needToLeave == false && rightInventoryPlace != null && collider.name == "LeftBag")
                {
                    if (gripButtonAction == true)
                    {

                        leftInventoryPlace = null; //Inventar ist dann leer;
                        takenSpawnedObject = true;
                        Debug.Log("Done");
                        spawnObject.GetComponent<XRGrabInteractable>().movementType = MovementTypeVelocity.GetComponent<XRGrabInteractable>().movementType;
                    }
                }
            }


            if (needToLeave == true)
            {
                needToLeave = false;
                Debug.Log("aus dem Inventar gegangen");
            }
        }
    }


    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        spawnObject = null;
    }

}