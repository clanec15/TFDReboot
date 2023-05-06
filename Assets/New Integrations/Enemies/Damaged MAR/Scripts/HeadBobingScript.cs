using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobingScript : MonoBehaviour
{
    public float xaxis;
    public float yaxis;
    public float zaxis;
    public Vector3 RandomRotation;
    public Quaternion CurrentRotation;
    public Quaternion RandomRotationQuaternion;
    public Light spotlight;
    // Start is called before the first frame update
    void Start()
    {
        spotlight = this.GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        CurrentRotation = this.transform.rotation;

        zaxis = UnityEngine.Random.Range(-0.5f, 0.5f);
        yaxis = UnityEngine.Random.Range(-20.0f, 20.0f);
        xaxis = UnityEngine.Random.Range(-20.0f, 20.0f);

        RandomRotation = new Vector3(xaxis, yaxis, zaxis);
        RandomRotationQuaternion.eulerAngles = RandomRotation;

        this.transform.rotation = RandomRotationQuaternion*CurrentRotation;

        spotlight.intensity = UnityEngine.Random.Range(20.0f, 100.0f);

    }
}
