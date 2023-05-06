using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenHinge : MonoBehaviour
{
    private Animation animcomp;

    private string[] animations;

    [SerializeField] private bool IsOpened;

    void Awake()
    {
        animcomp = gameObject.GetComponent<Animation>();
        animations = new string[] {"LaptopScriptOpening", "LaptopScriptClosing"};
        IsOpened = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
     {
            if (IsOpened == false)
            {
                animcomp.Play(animations[0]);
                IsOpened = true;
            }
            else
            {
                animcomp.Play(animations[1]);
                IsOpened = false;
            }
     }
    }
}
