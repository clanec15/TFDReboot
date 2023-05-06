using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class HunterAI : MonoBehaviour
{

    public Vector3 PlayerPosForAI;
    public Vector3 RandomDirection;
    public NavMeshAgent Agent;
    public bool diditarrive;
    public Component[] Lights;
    public bool isplayeronsight;
    public GameObject Player;
    public HunterAIRaycaster Raycasterscript;



    // Start is called before the first frame update
    void Start()
    {
        Lights = this.GetComponentsInChildren(typeof(Light));

        Agent = this.GetComponent<NavMeshAgent>();
        
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        diditarrive = Agent.remainingDistance <= 1.0f;
    
        if(diditarrive){
            RandomDirection = (Random.insideUnitSphere*20) + PlayerPosForAI;
        }

        PlayerPosForAI = Player.transform.position;

        if(diditarrive){
            Agent.SetDestination(RandomDirection);
        }

        if(isplayeronsight){
            foreach (Light lightchild in Lights)
            {
                lightchild.color = new Color(150, 4, 0, 255);
            }

        }

        else if(!isplayeronsight) {
            foreach (Light lightchild in Lights)
            {
                lightchild.color = new Color(0, 112, 150, 255);
            }
        }

        if(Raycasterscript.hit){
            StartCoroutine("PlayerPursuit");
        }

        else{
            StartCoroutine("DestinationSetting");
        }

        

        
    }
    IEnumerator DestinationSetting()
    {   
        
        Agent.SetDestination(RandomDirection);
        Agent.speed = 3;
        isplayeronsight = false;
        yield return new WaitForSeconds(5.0f);

    }

    IEnumerator PlayerPursuit()
    {
        Agent.SetDestination(PlayerPosForAI);
        Agent.speed = 10;
        isplayeronsight = true;
        yield return new WaitForSeconds(10.0f);
        Agent.speed = 3;
        isplayeronsight = false;
    }

}
