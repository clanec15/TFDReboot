using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthControllerV1 : MonoBehaviour
{
    public PulseDataLineRenderer pulseLineRenderer;
    public Color color;
    public TMP_Text healthText;

    //General Stats
    public float health, regenrate = 0.000035f, hunger = 500.0f, burnrate = 0.0000020f, thirst = 300.0f, thirstrate = 0.000002f, temp = 37.5f, normalizedValue;
    //Limb Healths
    //public List<float> bodyPartPts = new List<float>{20, 45, 45, 40, 30, 35, 35};
    public int healthcalc;

    public Gradient gradient;

    void Start()
    {
        pulseLineRenderer.dataFieldIndex = 1;
        health = 260.0f;
    }

    public int HealthCalc(float number){
        return Mathf.CeilToInt((number*100)/260);
    }

    void valueClamping(){
        hunger = Mathf.Clamp(hunger, 0, 500.0f);
        thirst = Mathf.Clamp(thirst, 0, 300.0f);
        temp = Mathf.Clamp(temp, 28.0f, 48.0f);
        health = Mathf.Clamp(health, 0, 260.0f);
    }

    void NecessitiesUpdate(){
        hunger -= (500*burnrate);
        thirst -= (300*thirstrate);
        //Including Slow Health regen
        if(health < 260.0f){
            health += regenrate;
        }
        
    }
    
    void Update()
    {
        valueClamping();
        NecessitiesUpdate();
        normalizedValue = healthcalc/100.0f;
        color = gradient.Evaluate(normalizedValue);
        
        
        healthcalc = HealthCalc(health);
        healthText.color = color;
        healthText.text = healthcalc.ToString() + "%";
        pulseLineRenderer.color = color;
    }
}
