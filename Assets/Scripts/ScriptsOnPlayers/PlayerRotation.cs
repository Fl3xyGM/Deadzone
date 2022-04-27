using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PlayerRotation : NetworkBehaviour {

    private PlayerListGame playerListGame;
    private PlayerManagerGame playerManagerGame;

    private Vector3 MousePos;
    private Vector3 ObjectPos;
    private float Angle;
    

    void Update() {
        playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
        playerManagerGame = GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>();

        if(isLocalPlayer && SceneManager.GetActiveScene().name == "TestScene") {
            MousePos = Input.mousePosition;
            MousePos.z = 10;
            ObjectPos = Camera.main.WorldToScreenPoint(playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.Find("RotatePoint").transform.position);
            MousePos.x = MousePos.x - ObjectPos.x;
            MousePos.y = MousePos.y - ObjectPos.y;
            Angle = Mathf.Atan2(MousePos.y, MousePos.x) * Mathf.Rad2Deg;
            // CmdRotatePlayer(playerManagerGame.PlayerPOS, Angle);
            playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.rotation = Quaternion.Slerp(playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.rotation, Quaternion.Euler(new Vector3(0, 0, Angle)), 50f*Time.deltaTime);
        }
    }

    [Command]
    public void CmdRotatePlayer(int PlayerPOS, float Angle) {
        PlayerListGame playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
        playerListGame.PlayerList[PlayerPOS-1].transform.rotation = Quaternion.Slerp(playerListGame.PlayerList[PlayerPOS-1].transform.rotation, Quaternion.Euler(new Vector3(0, 0, Angle)), 50f*Time.deltaTime);
        // RotatePlayer(PlayerPOS, Angle);
    }

    // [ClientRpc]
    // public void RotatePlayer(int PlayerPOS, float Angle) {
    //     PlayerListGame playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
    //     playerListGame.PlayerList[PlayerPOS-1].transform.rotation = Quaternion.Slerp(playerListGame.PlayerList[PlayerPOS-1].transform.rotation, Quaternion.Euler(new Vector3(0, 0, Angle)), 50f*Time.deltaTime);
    // }
    
}
