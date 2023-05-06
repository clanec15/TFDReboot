using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    public Button mainButton;
    public GameObject menuobj, newMenu;
    public Vector2 mouseLocation, spawnLocation;
    public InventoryControllerV3 mainCont;
    public InventoryControllerV2 secCont;
    public RectTransform menuRect;
    public Transform parent;
    public Item itemContainter;
    public MenuController cont;
    public bool menuInstantiated = false;
    public float MainValue, SecondaryValue;
    public string type;

    
    void SpawnMenu()
    {
        menuRect = menuobj.transform.GetComponent<RectTransform>();
        
        spawnLocation = Input.mousePosition + new Vector3((menuRect.rect.width/2)*menuRect.localScale.x, (-menuRect.rect.height/2)*menuRect.localScale.y);
        newMenu = Instantiate(menuobj, spawnLocation, Quaternion.identity, transform);
        cont = newMenu.GetComponent<MenuController>();
        cont.MainValue = MainValue;
        cont.SecondaryValue = SecondaryValue;
        cont.invList = secCont;
        cont.btnTypeString = type;
        cont.itemContainter = itemContainter;

    }

    void Start()
    {
        mainButton = transform.GetComponent<Button>();
        parent = transform.parent;
        mainCont = transform.parent.GetComponent<InventoryControllerV3>();
        secCont = mainCont.InvCont;

        mainButton.onClick.AddListener(delegate{
            
            if(!menuInstantiated){
                SpawnMenu();
                menuInstantiated=true;
                mainButton.interactable = false;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            if(newMenu)    {

                Destroy(newMenu);
                menuInstantiated=false;
                mainButton.interactable = true;
        
            }
        }

    }

}
