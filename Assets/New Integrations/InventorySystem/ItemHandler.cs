using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    
    public Item itemdata;

    public void Pickup()
    {
        InventoryControllerV2.Instance.Add(itemdata);
    }

}
