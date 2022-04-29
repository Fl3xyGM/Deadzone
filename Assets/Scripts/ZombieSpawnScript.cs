using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ZombieSpawnScript : NetworkBehaviour
{

    public GameObject EnemyPrefab;

    [Server]
    void Start() {
        GameObject[] ZombieSpawns = GameObject.FindGameObjectsWithTag("ZombieSpawn");
        List<GameObject> ZombieSpawnList = new List<GameObject>(ZombieSpawns);
        for(int i = 0; i < 75; i++) {
            int RandomNumber = Random.Range(0, ZombieSpawnList.Count);
            GameObject Zombie = Instantiate(EnemyPrefab, ZombieSpawnList[RandomNumber].transform.position, ZombieSpawnList[RandomNumber].transform.localRotation);
            NetworkServer.Spawn(Zombie);
            ZombieSpawnList.RemoveAt(RandomNumber);
        }        
    }

}
