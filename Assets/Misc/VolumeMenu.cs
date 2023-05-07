using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeMenu : MonoBehaviour
{
    public Slider volumeslider;
    public float volume;
    public Button Goback;

    public GameObject MainMenuMen;
    // Start is called before the first frame update
    void Awake()
    {
        
        Goback.onClick.AddListener(delegate {GoBackToMenu(Goback);});
    }

    void GoBackToMenu(Button btn)
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        MainMenuMen.SetActive(!MainMenuMen.gameObject.activeSelf);
    }

    void OnGUI()
    {
        AudioListener.volume = volumeslider.value;
    }


    
}
