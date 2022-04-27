using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PlayerPosition : NetworkBehaviour {
    
    public int PlayerPOS;

    void Update() {
        if(isLocalPlayer && SceneManager.GetActiveScene().name == "TestScene") {
            PlayerPOS = GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>().PlayerPOS;
        }
    }
}
