using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterAIRaycaster : MonoBehaviour
{
    public bool hit;
    public LayerMask mask;
    public HunterNearFieldDetectionScript TriggerScript;
    void Start()
    {
       mask = LayerMask.GetMask("Player");

    }

    void Update()
    {
        Debug.DrawRay(this.transform.position + this.transform.forward, this.transform.forward, Color.red);
    }

    void LateUpdate()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        hit = Physics.Raycast(this.transform.position + this.transform.forward, this.transform.forward, 20.0f, mask) || Vector3.Distance(this.transform.position, Player.transform.position) <= 10.0f || TriggerScript.NearFieldObject;
    }
}
