using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinding : MonoBehaviour
{


    public bool CursorStatus = false, activestatus;
    public GameObject inventory;
    public KeyCode InvKey;


    void ToggleKey(KeyCode key)
    {
        if(Input.GetKeyDown(InvKey)){
            inventory.SetActive(!inventory.activeSelf);
            activestatus = inventory.activeSelf;
            if(!CursorStatus){
                Cursor.lockState = CursorLockMode.Confined;
                CursorStatus = true;
            }

            else{
                Cursor.lockState = CursorLockMode.Locked;
                CursorStatus = false;
            }
        }
    }


    void Update()
    {
        
        ToggleKey(InvKey);
        
    }
}
