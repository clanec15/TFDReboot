using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public MemChk bootloaderscript;

    private Canvas EscCan;
    private Transform stapp;
    private Transform ndapp;
    private Transform rdapp;
    private bool neverDone;
    private bool neverdone2;
    private bool neverdone3;

    public Transform[] apps;
    [Range(0,2)]
    public int appsiterator = 1;

    private Transform upbuttonholder;
    private Transform downbuttonholder;
    private Transform enterbuttonholder;
    private Transform upbuttonholder2;
    public Transform UXMenu;
    public Transform appmenu;
    public Transform appmenuenabler;
    public Button upbutton;
    public Button enterbutton;
    public Button downButton;
    public string[] appnames;
    public Image buttonabrakadabra;

    // Start is called before the first frame update
    void Start()
    {
        appnames = new string[3];
        appnames[0] = "i2c";
        appnames[1] = "medify";
        appnames[2] = "rfidradar";

        GameObject tempObject = GameObject.Find("MainUI");

        if(tempObject != null){
            
            EscCan = tempObject.GetComponent<Canvas>();
            if(EscCan == null){
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }


        stapp = EscCan.transform.Find("i2c");
        ndapp = EscCan.transform.Find("medify");
        rdapp = EscCan.transform.Find("rfidradar");


        apps = new Transform[3];
        apps[0] = stapp;
        apps[1] = ndapp;
        apps[2] = rdapp;

        //UX menu finding
        UXMenu = EscCan.transform.Find("UXHolder");

        //up button finding
        upbuttonholder = EscCan.transform.Find("UXHolder");
        upbuttonholder2 = upbuttonholder.transform.Find("Up");
        upbutton = upbuttonholder2.GetComponent<Button>();
        
        //down button finding
        downbuttonholder = EscCan.transform.Find("UXHolder");
        downbuttonholder = downbuttonholder.transform.Find("Down");
        downButton = downbuttonholder.GetComponent<Button>();

        //Enter Button finding
        enterbuttonholder = EscCan.transform.Find("UXHolder");
        enterbuttonholder = enterbuttonholder.transform.Find("Enter");
        enterbutton = enterbuttonholder.GetComponent<Button>();


        neverDone = true;
        neverdone2 = true;
        neverdone3 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(bootloaderscript.timer >= 10.0f){
            if(neverdone2)
            {
                UXMenu.gameObject.SetActive(true);
                apps[1].gameObject.SetActive(true);
                neverdone2 = false;
            }
            
        }
        upbutton.onClick.AddListener(DownButtonClick);
        downButton.onClick.AddListener(UpButtonClick);
        enterbutton.onClick.AddListener(EnterButtonClick);
        buttonabrakadabra = apps[appsiterator].GetComponent<Image>();
        neverdone3 = true;
        neverDone = true;

        
    }

    void UpButtonClick()
    {
        if(neverDone)
        {
            
            appsiterator += 1;
            appsiterator = Mathf.Clamp(appsiterator, 0, apps.Length - 1);
            apps[appsiterator].gameObject.SetActive(true);
            apps[appsiterator - 1].gameObject.SetActive(false);
            

            neverDone = false;
            
        }
        

    }

    void DownButtonClick()
    {
        if(neverDone)
        {
            
            appsiterator -= 1;
            appsiterator = Mathf.Clamp(appsiterator, 0, apps.Length - 1);
            apps[appsiterator].gameObject.SetActive(true);
            apps[appsiterator + 1].gameObject.SetActive(false);

            neverDone = false;
            
        }
    }

    void EnterButtonClick()
    {
        if(neverdone3)
        {
            appmenu = apps[appsiterator];
            appmenuenabler = appmenu.transform.Find(appnames[appsiterator] + "Menu");
            UXMenu.gameObject.SetActive(false);
            appmenuenabler.gameObject.SetActive(true);
            buttonabrakadabra.enabled = false;

            neverdone3 = false;
        }
        
        
    }
}
