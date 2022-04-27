using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;
using UnityEngine.SceneManagement;

public class NoblePlayerSpawn : NobleNetworkManager {
    private GameObject Player;
    public override void OnClientConnect() {
        NetworkClient.Ready();
        NetworkClient.AddPlayer();
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn) {
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        if (SceneManager.GetActiveScene().name == "TestScene") {
            Player = Instantiate(playerPrefab, new Vector3(0.5f + (3.86f*(Players.Length)), -90f, 0), rotation);
        } else {
            Player = Instantiate(playerPrefab, new Vector3(-5.70f + (3.86f*(Players.Length)), 1.4f, 0), rotation);
        }
        
        Player.name = $"Player{Players.Length}";
        NetworkServer.AddPlayerForConnection(conn, Player);
    }



}
