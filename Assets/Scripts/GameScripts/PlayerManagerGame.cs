using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;

public class PlayerManagerGame : MonoBehaviour {
    
    [SerializeField] public int PlayerPOS;
    [SerializeField] public GameObject PlayerObject;

    void Update() {
        PlayerPOS = PlayerPrefs.GetInt("PlayerPOS");
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        PlayerObject = Players[PlayerPOS-1];
    }
}
