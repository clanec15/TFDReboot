using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetonatorAI : MonoBehaviour
{
    public Vector3 RandomDirection;
    public bool diditarrive;
    public Vector3 PlayerPosForAi;
    public NavMeshAgent Agent;
    public BoxCollider Trigger;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Trigger = this.GetComponent<BoxCollider>();
    }

    
    void LateUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //Distance Calculator
        if(diditarrive == true){
            RandomDirection = (UnityEngine.Random.insideUnitSphere*500) + PlayerPosForAi;
        }
        //End

        //Path End Detection V2
        diditarrive = Mathf.Floor(Agent.remainingDistance) <= 1;
        //End

        PlayerPosForAi = Player.transform.position;
        
    }

    void Update()
    {
        //Destination Setting
        if(diditarrive == true){
            Agent.SetDestination(RandomDirection);
        }
        //End

        if(Vector3.Distance(PlayerPosForAi, this.transform.position) <= 20.0f){
            Agent.SetDestination(PlayerPosForAi);
        }

        
    }   

}
