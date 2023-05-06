using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]


public class Item : ScriptableObject
{
    public enum ItemTp
    {
        INV,
        Food,
        Medicine,
        Ammo,
        Hardware
    }

    public ItemTp type;

    public float TypeValue;

    public float SecondaryTypeValue;

    public string Name;

    public string ItemDescription;

    public GameObject prefab;

    public float Weight;

}
