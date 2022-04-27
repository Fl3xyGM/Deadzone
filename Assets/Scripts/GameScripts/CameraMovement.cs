using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] public PlayerManagerGame playerManagerGame;
    [SerializeField] public PlayerListGame playerListGame;
    private Vector3 OldPosition;

    [SerializeField] public float seconds = 100f;

    void Update() {
        if(playerListGame.PlayerList.Count > 0 && playerManagerGame.PlayerPOS > 0) {
            transform.position = new Vector3(playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position.x, playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position.y, -10);
            //if(playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position != OldPosition) {
                //this.gameObject.transform.position = new Vector3(playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position.x, playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position.y, -10);
                //UpdateCam();
                //OldPosition = playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position;
            //}
        }
    }

    void UpdateCam() {
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, new Vector3(playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position.x, playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.position.y, -10), seconds*Time.deltaTime);
    }
    
}
