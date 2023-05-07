using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionMenu : MonoBehaviour
{
    public Button sixtyhertz, seventyfivehertz, onehundredfortyfourhertz, twohundredfortyhertz, hd, wxga, fhd, fullscreen, windowed, goback;
    public GameObject currentmenu, optionsmenu;
    public int refreshrate;
    public FullScreenMode screenmode;

    void Awake()
    {
        sixtyhertz.onClick.AddListener(delegate {SetAtSixtyHertz(sixtyhertz);});
        seventyfivehertz.onClick.AddListener(delegate {SetAtSeventyFiveHertz(seventyfivehertz);});
        onehundredfortyfourhertz.onClick.AddListener(delegate {SetAtOneHundredFort(onehundredfortyfourhertz);});
        twohundredfortyhertz.onClick.AddListener(delegate {SetAtTwoHundredfortyHertz(twohundredfortyhertz);});
        hd.onClick.AddListener(delegate {SetHD(hd);});
        wxga.onClick.AddListener(delegate {SetWXGA(wxga);});
        fhd.onClick.AddListener(delegate {SetFHD(fhd);});
        fullscreen.onClick.AddListener(delegate {SetFullScreen(fullscreen);});
        windowed.onClick.AddListener(delegate {SetWindowed(windowed);});
        goback.onClick.AddListener(delegate {exit(goback);});
    }

    void SetAtSixtyHertz(Button btn)
    {
        refreshrate = 60;
    }

    void SetAtSeventyFiveHertz(Button btn)
    {
        refreshrate = 75;
    }

    void SetAtOneHundredFort(Button btn)
    {
        refreshrate = 144;
    }

    void SetAtTwoHundredfortyHertz(Button btn)
    {
        refreshrate = 240;
    }

    void SetHD(Button btn)
    {
        Screen.SetResolution(1366, 768, screenmode, refreshrate);
    }

    void SetWXGA(Button btn)
    {
        Screen.SetResolution(1280, 720, screenmode, refreshrate);
    }

    void SetFHD(Button btn)
    {
        Screen.SetResolution(1920, 1080, screenmode, refreshrate);
    }

    void SetFullScreen(Button btn)
    {
        screenmode = FullScreenMode.FullScreenWindow;
    }

    void SetWindowed(Button btn)
    {
        screenmode = FullScreenMode.Windowed;
    }

    void exit(Button btn)
    {
        currentmenu.SetActive(!currentmenu.gameObject.activeSelf);
        optionsmenu.SetActive(!optionsmenu.gameObject.activeSelf);
    }

}
