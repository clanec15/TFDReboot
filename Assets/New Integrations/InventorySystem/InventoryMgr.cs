using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryMgr : MonoBehaviour
{

    public RaycastHit hit;
    public Canvas hand;

    public TMP_Text debugtext;

    public Item objdata;

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 50;
        Debug.DrawRay(transform.position, forward, Color.green);

        if(Physics.Raycast(transform.position, forward, out hit, 5) && hit.transform.gameObject.GetComponent<ItemHandler>()){
            hand.gameObject.SetActive(true);
            objdata = hit.transform.gameObject.GetComponent<ItemHandler>().itemdata;
            debugtext.text = "Name: " + objdata.Name + "\n\nDescription: " + objdata.ItemDescription;

            if(Input.GetKey(KeyCode.K)){
                hit.transform.gameObject.GetComponent<ItemHandler>().Pickup();
                Destroy(hit.transform.gameObject);
            }
        }

        else{
            hand.gameObject.SetActive(false);
        }
    }
}
