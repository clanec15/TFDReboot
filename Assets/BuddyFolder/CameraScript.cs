using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{

    public float Sensitivity = 90f;
    public Transform Body;

    float xRotation = 0f;



    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera controller
        float Xaxis = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float Yaxis = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        
        xRotation -= Yaxis;
        xRotation = Mathf.Clamp(xRotation, -20.2f, 12.3f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 90f, 0f);
        Body.Rotate(Vector3.up * Xaxis);
    }
}