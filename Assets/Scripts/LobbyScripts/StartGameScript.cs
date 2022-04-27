using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;

public class StartGameScript : NetworkBehaviour {
    
    private NobleNetworkManager networkManager;

    void Update() {
        networkManager = GameObject.Find("NobleConnectNetworkManager").GetComponent<NobleNetworkManager>();
    }


    public void StartGame() {
        networkManager.ServerChangeScene("TestScene");
    }


}
