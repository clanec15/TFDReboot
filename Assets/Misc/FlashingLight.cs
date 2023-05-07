using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlashingLight : MonoBehaviour
{
    private float minInclusive = 0.4f, MaxInclusive = 0.5f;
    [SerializeField] private Light Lighttobemodified;


    void Start()
    {   
        Lighttobemodified = this.GetComponent<Light>();
    }

    private void Update()
    {
        Lighttobemodified.intensity = Random.Range(minInclusive, MaxInclusive);
    }
}
