using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainConsole : MonoBehaviour
{
    public Button SSAButton, CrucnhButton;
    public GameObject SSAMenu, CrunchMenu;

    void Awake()
    {
        SSAButton.onClick.AddListener(delegate {SSAwake(SSAButton);});
        CrucnhButton.onClick.AddListener(delegate {CrunchAwake(CrucnhButton);});
    }

    void SSAwake(Button btn)
    {
        SSAMenu.SetActive(!SSAMenu.activeSelf);
    }

    void CrunchAwake(Button Btn)
    {
        CrunchMenu.SetActive(!CrunchMenu.activeSelf);
    }
}
