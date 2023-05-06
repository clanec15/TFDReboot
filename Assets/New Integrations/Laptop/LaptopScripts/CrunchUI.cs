using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrunchUI : MonoBehaviour
{
    public Text MaxChar, MinChar, CrunchCLI;
    public Toggle Pattern, SameNumChar;
    public bool PatternToggle = false, SameNumCharToggle = false;
    public Button MoreCharMax, LessCharMax, MoreCharMin, LessCharMin,ExitButton;
    public InputField charset, pattern;
    [Range(1,8)]
    public int MaxCharNumb = 1, MinCharNumb = 1, MaxCharCache, MinCharCache;

    void Awake()
    {
        MoreCharMax.onClick.AddListener(MoreCharMaxClick);
        LessCharMin.onClick.AddListener(LessCharMinClick);
        MoreCharMin.onClick.AddListener(MoreCharMinClick);
        LessCharMax.onClick.AddListener(LessCharMaxClick);
        ExitButton.onClick.AddListener(delegate {Exit();});
        Pattern.onValueChanged.AddListener(delegate { 
            PatternOn(Pattern);
        });
        SameNumChar.onValueChanged.AddListener(delegate { 
            SameNumberofChar(SameNumChar);
        });
    }

    void MoreCharMaxClick()
    {
        MaxCharNumb += 1;
        MaxCharCache = MaxCharNumb;
        MaxCharNumb = Mathf.Clamp(MaxCharNumb, 1, 9);

        
        MaxChar.text = MaxCharNumb.ToString();
    }

    void LessCharMinClick()
    {

        MinCharNumb -= 1;
        MinCharCache = MinCharNumb;
        MinCharNumb = Mathf.Clamp(MinCharNumb, 1, 9);

        
        MinChar.text = MinCharNumb.ToString();
    }

    void MoreCharMinClick()
    {
 
        MinCharNumb += 1;
        MinCharCache = MinCharNumb;
        MinCharNumb = Mathf.Clamp(MinCharNumb, 1, 9);

        MinChar.text = MinCharNumb.ToString();
    }

    void LessCharMaxClick()
    {
        MaxCharNumb -= 1;
        MaxCharCache = MaxCharNumb;
        MaxCharNumb = Mathf.Clamp(MaxCharNumb, 1, 9);
        
        MaxChar.text = MaxCharNumb.ToString();
    }

    

    void SameNumberofChar(Toggle tgglVal)
    {
        SameNumCharToggle = !SameNumCharToggle;
    }

    void PatternOn(Toggle tgglVal)
    {
        PatternToggle = !PatternToggle;
    }

    void Exit()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
    
    void Update()
    {
        
        if(SameNumCharToggle == true){
            MaxCharNumb = MinCharNumb;
            MoreCharMax.interactable = false;
            LessCharMax.interactable = false;
        }

        else{
            MaxCharNumb = MaxCharCache;
            MoreCharMax.interactable = true;
            LessCharMax.interactable = true;
        }

        if(PatternToggle == false){
            pattern.interactable = false;
        }
        
        else{
            pattern.interactable = true;
        }


        CrunchCLI.text = "crunch " + MinCharNumb.ToString() + " " + MaxCharNumb.ToString() + " " + charset.text;
    }

}
