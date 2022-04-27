using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovement : NetworkBehaviour {

    public float Speed = 5f;
    private PlayerListGame playerListGame;
    private PlayerManagerGame playerManagerGame;

    void Update() {
        if(SceneManager.GetActiveScene().name == "TestScene") {
            playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
            playerManagerGame = GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>();

            // GameObject[] LocalPlayers = GameObject.FindGameObjectsWithTag("Player");
            // if(LocalPlayers.Length > 0) {
            //     LocalPlayers[0].transform.position = playerListGame.PlayerList[0].transform.position;
            // }
            // if(LocalPlayers.Length > 1) {
            //     LocalPlayers[1].transform.position = playerListGame.PlayerList[1].transform.position;
            // }
            // if(LocalPlayers.Length > 2) {
            //     LocalPlayers[2].transform.position = playerListGame.PlayerList[2].transform.position;
            // }
            // if(LocalPlayers.Length > 3) {
            //     LocalPlayers[3].transform.position = playerListGame.PlayerList[3].transform.position;
            // }
        }

        if(isLocalPlayer && SceneManager.GetActiveScene().name == "TestScene") {

            if (Input.GetKey(KeyCode.D)) {
                // CmdUpdatePlayerMovement(playerManagerGame.PlayerPOS, "RIGHT");
                playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position += Vector3.right * Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A)) {
                // CmdUpdatePlayerMovement(playerManagerGame.PlayerPOS, "LEFT");
                playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position += Vector3.right * -Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W)) {
                // CmdUpdatePlayerMovement(playerManagerGame.PlayerPOS, "UP");
                playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position += Vector3.up * Speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S)) {
                // CmdUpdatePlayerMovement(playerManagerGame.PlayerPOS, "DOWN");
                playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position += Vector3.up * -Speed * Time.deltaTime;
            }

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
                playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].GetComponent<AnimationChooser>().Moving = true;
            }
            if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) {
                playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].GetComponent<AnimationChooser>().Moving = false;
            }



        }
    }

    [Command]
    public void CmdUpdatePlayerMovement(int PlayerPOS, string Direction) {

        if(Direction == "RIGHT") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.right * Speed * Time.deltaTime;
            this.gameObject.GetComponent<PlayerCommand>().HasBeenRun = false;
        }
        if(Direction == "LEFT") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.right * -Speed * Time.deltaTime;
            this.gameObject.GetComponent<PlayerCommand>().HasBeenRun = false;
        }
        if(Direction == "UP") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.up * Speed * Time.deltaTime;
            this.gameObject.GetComponent<PlayerCommand>().HasBeenRun = false;
        }
        if(Direction == "DOWN") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.up * -Speed * Time.deltaTime;
            this.gameObject.GetComponent<PlayerCommand>().HasBeenRun = false;
        }
        //RpcPlayerMovement(PlayerPOS, Direction);

    }

    [ClientRpc]
    public void RpcPlayerMovement(int PlayerPOS, string Direction) {
        if(Direction == "RIGHT") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        if(Direction == "LEFT") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.right * -Speed * Time.deltaTime;
        }
        if(Direction == "UP") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.up * Speed * Time.deltaTime;
        }
        if(Direction == "DOWN") {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[PlayerPOS-1].transform.position += Vector3.up * -Speed * Time.deltaTime;
        }
    }
}
