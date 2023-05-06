using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReturnButton : MonoBehaviour
{

    public UIScript UIScriptpointer;
    private Button returnbutton;
    private Transform returnbuttonholder;
    private bool neverDone;

    // Start is called before the first frame update
    void Start()
    {
        returnbuttonholder = UIScriptpointer.appmenuenabler.Find("ReturnButton");
        returnbutton = returnbuttonholder.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        returnbutton.onClick.AddListener(ReturnToMainMenu);
        neverDone = true;
        
    }

    void ReturnToMainMenu()
    {
        if(neverDone)
        {
            UIScriptpointer.UXMenu.gameObject.SetActive(true);
            UIScriptpointer.buttonabrakadabra.enabled = true;
            UIScriptpointer.appmenuenabler.gameObject.SetActive(false);
            neverDone = false;
        }
            
    }
}
