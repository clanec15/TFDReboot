using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button Fst, Sec, Thd;
    public GameObject[] menus;
    [SerializeField] private int cache = 0;
    void Awake()
    {
        Fst.onClick.AddListener(delegate {
            MenuChanger(Fst, 1);
        });

        Fst.onClick.AddListener(delegate{
            MenuChanger(Fst, 0);
        });

        Fst.onClick.AddListener(delegate{
            MenuChanger(Fst, 2);
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
