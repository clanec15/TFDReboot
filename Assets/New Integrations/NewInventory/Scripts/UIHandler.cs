using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Button InvButton, StatsButton, WetwareMenu;
    public GameObject[] menus;
    [SerializeField] private int cache = 0;
    void Awake()
    {
        InvButton.onClick.AddListener(delegate {
            MenuChanger(InvButton, 1);
        });

        StatsButton.onClick.AddListener(delegate{
            MenuChanger(StatsButton, 0);
        });

        WetwareMenu.onClick.AddListener(delegate{
            MenuChanger(WetwareMenu, 2);
        });
    }
    void MenuChanger(Button btn, int id)
    {
        if(cache == id){
            menus[id].gameObject.SetActive(true);
        }
        else{
            menus[id].gameObject.SetActive(true);
            menus[cache].gameObject.SetActive(false);
        }
        cache = id;
    }
}