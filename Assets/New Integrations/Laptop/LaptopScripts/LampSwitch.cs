using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LampSwitch : MonoBehaviour
{

    public float minranbrightness;
    public float maxranbrightness;
    Light lt;
    public float red;
    public float green;
    public float blue;
    public bool stoptime;
    public int waittime;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();

        if(stoptime == true) {
            StartCoroutine(DelayedFlickering());
        }

    }

    // Update is called once per frame
    void Update()
    {
        lt.color = new Color(red, green, blue);

        if(stoptime != true){
            lt.intensity = Random.Range(minranbrightness, maxranbrightness);
        }
        
    }

    IEnumerator DelayedFlickering()
        {
            while(true)
            {
                lt.intensity = Random.Range(minranbrightness, maxranbrightness);
                yield return new WaitForSeconds(waittime);
                lt.intensity = Random.Range(minranbrightness, maxranbrightness);
            }
        }
}
