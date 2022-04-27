using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointCounter : MonoBehaviour {

    [SerializeField] public GameObject[] SpawnPoints;
    
    void Update() {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        
    }
}
