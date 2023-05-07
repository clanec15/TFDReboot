using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button StartGame, Options, exit;
    public GameObject OptionsMenu,MainMenu;
    public Text LoadingText;

    void Awake()
    {   
        if (MainMenu.gameObject.activeSelf == false){
            MainMenu.gameObject.SetActive(true);
        }

        StartGame.onClick.AddListener(delegate {LoadMainWorld(StartGame);});
        Options.onClick.AddListener(delegate {optionmenushower(Options);});
        exit.onClick.AddListener(delegate {Exit(exit);});
    }


    void LoadMainWorld(Button StartButton)
    {
        LoadingText.gameObject.SetActive(true);
        SceneManager.LoadScene(1);
    }
    void optionmenushower(Button Optionsbutton)
    {   
        OptionsMenu.SetActive(!false);
        MainMenu.SetActive(!true);
    }

    void Exit(Button ExitButton)
    {
        Application.Quit();
    }
}
