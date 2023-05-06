using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
//using System.Linq.Enumerable;
using UnityEngine;

public class IDDetector : MonoBehaviour
{
    public int ids;
    public SphereCollider rfidCollider;
    private Vector3 position;
    public List<int> TagInt = new List<int>();
    public Collider[] currentcolliders;

    void Start()
    {
        ids = 0;
        currentcolliders = new Collider[] {rfidCollider};
        position = rfidCollider.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ids = 0;
        currentcolliders = Physics.OverlapSphere(rfidCollider.transform.position, rfidCollider.radius);
        foreach (Collider collider in currentcolliders)
        {
            if (collider.gameObject.CompareTag("RFIDTag"))
            {
                ids++;
            }

            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        IDGenerator idGen = other.transform.GetComponent<IDGenerator>();
        if (idGen != null)
        {
            int id = idGen.seed;
            TagInt.Add(id);
        }
    }

    void OnTriggerExit(Collider other)
    {
        IDGenerator idGen = other.transform.GetComponent<IDGenerator>();
        if (idGen != null)
        {
            int id = idGen.seed;
            TagInt.Remove(id);
        }
    }

    void OnDisable()
    {
        //ids = 0;
    }


}
