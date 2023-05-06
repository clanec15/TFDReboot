using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class SoundFXChanger : MonoBehaviour
{
    public AudioClip SSTVTransmission;
    public AudioClip[] PAAudios;
    public AudioClip PlayerDetected;
    public AudioClip PlayerOutOfSight;
    public AudioClip ExternalSignalDetected;
    public AudioSource PASystem;

    
    // Start is called before the first frame update
    void Start()
    {
        PASystem = this.GetComponent<AudioSource>();
        StartCoroutine("SwitchAudio");
    }
    
    IEnumerator SwitchAudio()
    {
        float WaitTime;
        float PossibleSSTVRecive;
        float Pitching;
        Pitching = Random.Range(0.5f, 1.01f);
        PossibleSSTVRecive = Random.Range(0.0f, 5000.0f);
        WaitTime = Random.Range(1.5f, 10.0f);
        
        if(PossibleSSTVRecive == Random.Range(3000.0f, 3500.0f)){
            PASystem.pitch = 1.0f;
            PASystem.PlayOneShot(SSTVTransmission);
            yield return new WaitUntil(() => PASystem.isPlaying != true);
            StartCoroutine("SwitchAudio");
        }

        PASystem.pitch = Pitching;
        PASystem.PlayOneShot(PAAudios[Random.Range(0, PAAudios.Length)]);
        yield return new WaitUntil(() => PASystem.isPlaying == false);
        yield return new WaitForSeconds(WaitTime);
        StartCoroutine("SwitchAudio");
    }
}
