using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RFIDTracker : MonoBehaviour
{
    public Vector3 player;
    public Transform RFIDTrackable;
    public float distance;
    public AudioSource beepboi;
    private int nextUpdate=2;
    private int ruleof3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject RFIDTrackableholder = GameObject.FindGameObjectWithTag("RFIDTrackable");
        RFIDTrackable = RFIDTrackableholder.GetComponent<Transform>();
        beepboi = this.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {

        player = this.transform.position;
       
        distance = Vector3.Distance(player, RFIDTrackable.transform.position);
        int distancenew = Mathf.FloorToInt(distance);

        if(Time.time>=nextUpdate){
             Debug.Log(Time.time+">="+nextUpdate);
             Debug.Log("Distance: " + distance);

             ruleof3 = (distancenew*20)/1000;


             
             nextUpdate=Mathf.FloorToInt(Time.time)+ruleof3;
            
             PlaySound();
        }
        
        
        
               

    }

    void PlaySound()
    {
        int sampleFreq = 44000;
        float frequency = 3840;
 
        float[] samples = new float[44000];
        for(int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(Mathf.PI*2*i*frequency/sampleFreq);
        }
        AudioClip ac = AudioClip.Create("Test", samples.Length, 1, sampleFreq, false);
        ac.SetData(samples, 0);

        
        beepboi.PlayOneShot(ac);


    }
}
