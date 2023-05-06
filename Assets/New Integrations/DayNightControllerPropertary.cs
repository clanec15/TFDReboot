using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightControllerPropertary : MonoBehaviour
{
    public GameObject Sun;
    public Light SunLightComp;
    public Transform SunTransformComp;
    public float xcompsineval, timeinseconds, SunRotation;


    void Update()
    {
        SunTransformComp = Sun.GetComponent<Transform>();
        SunRotation = Mathf.Abs(SunTransformComp.localEulerAngles.x * 0.01745329251f);
        xcompsineval = Mathf.Sin(SunRotation);

        SunLightComp.intensity = xcompsineval;

        RenderSettings.fogDensity = Mathf.Lerp(0.25f, 0.01f, Mathf.Abs(xcompsineval));

        SunTransformComp.Rotate(new Vector3(secondstorotation(timeinseconds) * Time.fixedDeltaTime, 0, 0));
    }

    float secondstorotation(float seconds)
    {
        float division;
        float result;

        division = seconds / 120;
        result = 1/(2*division);
        
        return result;
    }
}
