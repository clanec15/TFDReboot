using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour
{
    public Button CloseButton;
    public  GameObject MenuToClose;

    void CloseMen(Button btn)
    {
        if(MenuToClose.activeSelf == true){
            MenuToClose.SetActive(false);
        }
    }

    void Awake()
    {
        CloseButton.onClick.AddListener(delegate {
            CloseMen(CloseButton);
        });
    }
}
