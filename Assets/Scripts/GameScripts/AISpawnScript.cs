using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AISpawnScript : NetworkBehaviour
{
    public GameObject EnemyPrefab, SurvivorPrefab;
    void Start() {
        StartCoroutine(waitForPlayers());
    }
    IEnumerator waitForPlayers() {
        yield  return new WaitForSeconds(5);
        spawnEnemy();
    }
    [Server]
    private void spawnEnemy() {
        GameObject Zombie = Instantiate(EnemyPrefab);
        NetworkServer.Spawn(Zombie);
        // GameObject Survivor = Instantiate(SurvivorPrefab);
        // NetworkServer.Spawn(Survivor);
    }
}