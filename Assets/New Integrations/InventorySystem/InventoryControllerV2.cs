using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerV2 : MonoBehaviour
{

    public static InventoryControllerV2 Instance;

    public List<Item> invItems = new List<Item>();
    
    void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        invItems.Add(item);
    }

    public void Remove(Item itemr)
    {
        invItems.Remove(itemr);
    }
}
