using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RFIDRadar : MonoBehaviour
{
    public RFIDTracker rfidmainscript;
    public Transform Obj,Obj2;
    public Text m_obj,m_obj2;
    public GameObject tempObject;
    private int nextUpdate=2;
    public GameObject[] RFIDTrackables;

    

    // Start is called before the first frame update
    void Start()
    {
        RFIDTrackables = new GameObject [5];
        

        tempObject = GameObject.Find("rfidradarMenu");


        Obj = tempObject.transform.Find("DistanceMarker");
        m_obj = Obj.GetComponent<Text>();

        Obj2 = tempObject.transform.Find("EnemyCounter");
        m_obj2 = Obj2.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RFIDTrackables = GameObject.FindGameObjectsWithTag("RFIDTrackable");

        if(Time.time>=nextUpdate){
             Debug.Log(Time.time+">="+nextUpdate);
             Debug.Log("Distance: " + rfidmainscript.distance);
    
             nextUpdate=Mathf.FloorToInt(Time.time)+2;
            
             UpdateText();
        }
       
    }

    void UpdateText()
    {
        m_obj.text = "Distance: " + rfidmainscript.distance + "m";
        m_obj2.text = "LoRa signals detected: " + RFIDTrackables.Length;

    }
}
