using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public Button ChangeResOptions, SetVolumeOptions, Credits, GoBackButton;
    public GameObject OptionsMenu,ChangeResMen, SetVolumeMen, MainMenuMen;
    // Start is called before the first frame update
    void Awake()
    {
        ChangeResOptions.onClick.AddListener(delegate {ChangeResMenu(ChangeResOptions);});
        SetVolumeOptions.onClick.AddListener(delegate {SetVolumeMenu(SetVolumeOptions);});
        GoBackButton.onClick.AddListener(delegate {GoBack(GoBackButton);});
    }

    void ChangeResMenu(Button ChangeRes)
    {
        ChangeResMen.SetActive(!ChangeResMen.gameObject.activeSelf);
        OptionsMenu.SetActive(!OptionsMenu.gameObject.activeSelf);
    }

    void SetVolumeMenu(Button VolumeSet)
    {
        SetVolumeMen.SetActive(!SetVolumeMen.gameObject.activeSelf);
        OptionsMenu.SetActive(!OptionsMenu.gameObject.activeSelf);
    }

    void GoBack(Button GoBack)
    {
        OptionsMenu.SetActive(!OptionsMenu.gameObject.activeSelf);
        MainMenuMen.SetActive(!MainMenuMen.gameObject.activeSelf);

    }
}
