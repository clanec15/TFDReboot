using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FogLerp : MonoBehaviour
{

    public float fogquantity;
    public Light SunObj;
    public GameObject SunTransform;
    public Vector3 sunrotation;

    // Update is called once per frame
    void Update()
    {
        sunrotation = SunTransform.GetComponent<Transform>().rotation.eulerAngles;
        fogquantity = Mathf.Lerp(0.01f, 0.1f, Mathf.Abs(sunrotation.x/100));
        
        RenderSettings.fogDensity = fogquantity;
    }
}
