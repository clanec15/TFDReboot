using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public SphereCollider m_Maincollider;
    public GameObject m_go;
    float distance = 5.0f;

    void Update()
    {
        Vector3 CurrentPos;
        Vector3 PlayerPos;
        CurrentPos = this.transform.position;
        PlayerPos = GameObject.FindWithTag("Player").transform.position;

        //Debug.Log(Vector3.Distance(CurrentPos, PlayerPos));

        if(Vector3.Distance(CurrentPos, PlayerPos) <= distance){
            m_Maincollider.radius = 4.0f;
            Destroy(m_go,0.1f);
        }
    }
}
