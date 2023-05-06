using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControllerV2 : MonoBehaviour
{

    public float Sensitivity = 80f;
    public Transform PlayerColl;
    public float xrotation = 0;

    
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    
    void Update()
    {
        float xMouseAxis = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float yMouseAxis = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;


        xrotation = Mathf.Clamp(xrotation, -50f, 32f);
        xrotation -= yMouseAxis;
        Quaternion camRotation = Quaternion.AngleAxis(xrotation, Vector3.left);
        transform.localRotation = camRotation;

        PlayerColl.Rotate(Vector3.up * xMouseAxis);


    }
}
