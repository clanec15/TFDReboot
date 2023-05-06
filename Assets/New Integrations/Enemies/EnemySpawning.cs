using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawning : MonoBehaviour
{
    public GameObject hunterPrefab;
    public GameObject detonatorPrefab;
    public GameObject[] spawningZones;

    const int initialSeed = 3423;
    const float spawnInterval = 5f;

    void Start()
    {
        spawningZones = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Random.InitState(initialSeed);
        //StartCoroutine(SpawnNPCs(hunterPrefab, "Hunter"));
        StartCoroutine(SpawnNPCs(detonatorPrefab, "Detonator"));
    }

    IEnumerator SpawnNPCs(GameObject prefab, string npcType)
    {
        while (true)
        {
            GameObject[] npcs = GameObject.FindGameObjectsWithTag(npcType + "NPC");
            if (npcs.Length == 1)
            {
                yield return new WaitForSeconds(spawnInterval);
                continue;
            }

            GameObject zone = spawningZones[Random.Range(0, spawningZones.Length)];
            Instantiate(prefab, zone.transform.position, zone.transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
