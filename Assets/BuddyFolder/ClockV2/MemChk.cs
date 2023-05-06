using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemChk : MonoBehaviour
{

    Text memchk;
    private int memory = 4194304;
    private int checkedmem;
    private Canvas EscCan;
    private Transform bootscreen;
    private bool UIScreenIndicator;
    private bool FirstAppIndicator;
    public float timer;

    public UIScript UIscriptpointer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObject = GameObject.Find("BootloaderScreen");

        if(tempObject != null){
            
            EscCan = tempObject.GetComponent<Canvas>();
            if(EscCan == null){
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }


        bootscreen = EscCan.transform.Find("bootscreen");
        Transform tempobj2 = bootscreen.transform.Find("memtext");


        if(tempobj2 == null)
        {
            Debug.Log("Couldn't find text element");
        }


        memchk = tempobj2.GetComponent<Text>();

        UIScreenIndicator = UIscriptpointer.UXMenu.gameObject.activeSelf;
        FirstAppIndicator = UIscriptpointer.apps[1].gameObject.activeSelf;



        
    }

    // Update is called once per frame
    void Update()
    {

        if (checkedmem == memory)
        {
            memchk.text = memory + "K  OK";

            if(UIScreenIndicator == false && FirstAppIndicator == false)
            {
                timer += Time.deltaTime*1;
            }

            else
            {
                timer = 10.0f;
            }

            
            if(timer >= 10.0f)
            {
                bootscreen.gameObject.SetActive(false);
                timer = 10.0f;
            }
        } 

        else
        {
            checkedmem += 1024;
            memchk.text = checkedmem + "k";
        }

        

    }
}
