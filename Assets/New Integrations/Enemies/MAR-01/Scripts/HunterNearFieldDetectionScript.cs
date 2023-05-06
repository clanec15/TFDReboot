using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterNearFieldDetectionScript : MonoBehaviour
{
    public bool NearFieldObject;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            NearFieldObject = true;
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            NearFieldObject = false;
        }    


    }

    
}
