using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLockFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject savedHand;
    bool stayThere;
    GameObject N1;

    public GameObject M1;
    public GameObject M2;
    public GameObject M3;
    public GameObject M4;

    private void Start()
    {

        switch (this.gameObject.name)
        {
            case "Rad1null":
                N1 = this.gameObject;
                break;
            case "Rad2null":
                N1 = this.gameObject;
                break;
            case "Rad3null":
                N1 = this.gameObject;
                break;
            case "Rad4null":
                N1 = this.gameObject;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            //other.gameObject.transform.position = this.transform.position;
            savedHand = other.gameObject;
            stayThere = true;
            savedHand.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Hit");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            stayThere = false;
            savedHand.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (stayThere == true)
        {
            savedHand.GetComponent<Inventory>().HitObject = N1;
        }
    }

}
