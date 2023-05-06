using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuController : MonoBehaviour
{
    public Button invButton, RemoveButton, InspectButton;
    public string btnTypeString;
    public Transform menu, insttransform;
    public HealthControllerV1 player;
    public Vector3 testvector;

    public Item itemContainter;
    public InventoryControllerV2 invList;
    public float MainValue, SecondaryValue;
    


    void Start()
    {
        menu = transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<HealthControllerV1>();

        switch(btnTypeString){
            case "Food":
                menu.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Consume";
                invButton.onClick.AddListener(delegate{
                    FoodMenu();
                    RemoveItem();
                });
                
                break;

            case "Medicine":
                invButton.onClick.AddListener(delegate{
                    menu.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Use";
                    MedicineMenu();
                    RemoveItem();
                });
                break;

            case "Ammo":
                invButton.onClick.AddListener(delegate{
                    menu.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "WIP";
                    AmmoMenu();
                    RemoveItem();
                });
                break;
        }


        RemoveButton.onClick.AddListener(delegate{
            RemoveItem();
        });

        insttransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void RemoveItem(){
        Quaternion newRot = Random.rotation;
        testvector = insttransform.position;
        GameObject invItemInst = Instantiate(itemContainter.prefab, insttransform.position + new Vector3(0, 2, 5), newRot, insttransform);
        

        invItemInst.AddComponent<Rigidbody>();
        invItemInst.GetComponent<Rigidbody>().mass = itemContainter.Weight;
        invItemInst.transform.parent = null;

        invList.Remove(itemContainter);
        
    }
    

    void FoodMenu(){
        if(MainValue == 0 && SecondaryValue != 0){
            player.thirst += SecondaryValue;
        } else{
            player.hunger += MainValue;
        }
    }

    void MedicineMenu(){
        player.health += MainValue;
    }

    void AmmoMenu(){
        Debug.Log("WIP!!");
    }
}
