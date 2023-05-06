using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDriveScript : MonoBehaviour
{
    public float HardDriveCapacity;
    

    public float[] StorageSettings;
    

    void Awake()
    {
        StorageSettings = new float[] {120.0f, 256.0f, 500f, 1000.0f, 1500.0f, 2000.0f, 4000.0f}; 
        HardDriveCapacity = StorageSettings[Random.Range(0, StorageSettings.Length)];
    }

}


