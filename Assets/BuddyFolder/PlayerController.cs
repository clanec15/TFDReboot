using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour

{
    public float grav = -9.80665f, jumpheight = 1, speed = 12f;
    public bool isgrounded;
    public CharacterController charcontrll; 
    Vector3 vel;
    public Vector3 Playermove;
    void Update()
    {

        isgrounded = charcontrll.isGrounded;

        if(isgrounded && vel.y < 0)
        {
            vel.y = 0f;
        }

        float xPlane = Input.GetAxis("Horizontal");
        float zPlane = Input.GetAxis("Vertical");

        Playermove = transform.right * xPlane + transform.forward * zPlane;
        charcontrll.Move(Playermove * speed * Time.deltaTime);

        vel.y += grav * Mathf.Pow(Time.fixedDeltaTime, 2f);

        if(Input.GetButton("Jump") && isgrounded)
        {
            vel.y = (Mathf.Sqrt(jumpheight * -2f * grav));
        }
        
        charcontrll.Move(vel);
    }
}
