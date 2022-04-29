using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SurvivorSpawnScript : NetworkBehaviour
{

    public GameObject SurvivorPrefab;
    private GameObject[] Players;

    [Server]
    void Start() {
        StartCoroutine(SpawnSurvivor());
    }

    IEnumerator SpawnSurvivor() {
        yield return new WaitForSeconds(1);
        Players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] SurvivorSpawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        List<GameObject> SurvivorSpawnList = new List<GameObject>(SurvivorSpawns);
        for(int i = 0; i < Players.Length*3; i++) {
            int RandomNumber = Random.Range(0, SurvivorSpawnList.Count);
            GameObject Survivor = Instantiate(SurvivorPrefab, SurvivorSpawnList[RandomNumber].transform.position, SurvivorSpawnList[RandomNumber].transform.localRotation);
            NetworkServer.Spawn(Survivor);
            SurvivorSpawnList.RemoveAt(RandomNumber);
        }        
    }

}
