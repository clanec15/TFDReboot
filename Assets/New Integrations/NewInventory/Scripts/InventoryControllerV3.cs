using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryControllerV3 : MonoBehaviour
{
    public int i = 0;
    public float weight;
    public bool finished;
    public GameObject placeholder;
    public RectTransform parent;
    public InventoryControllerV2 InvCont;
    void OnEnable()
    {
        finished = false;
    }
    
    void Update() {
    	if(!finished){
            foreach(Item it in InvCont.invItems){

                float xcord = (-610 + (200*i));

                ButtonController buttonContainer;

                Vector3 newpos = new Vector3(xcord, 200, 0);
                GameObject invButton = Instantiate(placeholder, parent);
                invButton.GetComponent<RectTransform>().anchoredPosition = newpos;
                invButton.GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = InvCont.invItems[i].Name;
                buttonContainer = invButton.GetComponent<ButtonController>();
                buttonContainer.type = InvCont.invItems[i].type.ToString();
                buttonContainer.MainValue = InvCont.invItems[i].TypeValue;
                buttonContainer.SecondaryValue = InvCont.invItems[i].SecondaryTypeValue;
                buttonContainer.itemContainter = InvCont.invItems[i];

                i++
                ;
            }
            finished = true;
        }
    }

    void OnDisable()
    {
        i = 0;
        foreach(Transform child in parent){
            Destroy(child.gameObject);
        }
    }

}
