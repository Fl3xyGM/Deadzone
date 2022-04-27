using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class LobbyUI : NetworkBehaviour
{
    public GameObject waitingForPlayer1, waitingForPlayer2, 
    waitingForPlayer3, waitingForPlayer4, p1, p2, p3, p4, ReadyLight1, ReadyLight2, ReadyLight3, ReadyLight4;

    public PlayerList playerList;
    
    void Update() {

        if(playerList.ListOfPlayers.Count >= 1) {
            waitingForPlayer1.SetActive(false);
            p1.SetActive(true);
            ReadyLight1.SetActive(true);
        }

        if(playerList.ListOfPlayers.Count >= 2) {
            waitingForPlayer2.SetActive(false);
            p2.SetActive(true);
            ReadyLight2.SetActive(true);
        }

        if(playerList.ListOfPlayers.Count >= 3) {
            waitingForPlayer3.SetActive(false);
            p3.SetActive(true);
            ReadyLight3.SetActive(true);
        }

        if(playerList.ListOfPlayers.Count == 4) {
            waitingForPlayer4.SetActive(false);
            p4.SetActive(true);
            ReadyLight4.SetActive(true);
        }

        if(playerList.ListOfPlayers.Count < 2) {
            waitingForPlayer2.SetActive(true);
            p2.SetActive(false);
            ReadyLight2.SetActive(false);
        }

        if(playerList.ListOfPlayers.Count < 3) {
            waitingForPlayer3.SetActive(true);
            p3.SetActive(false);
            ReadyLight3.SetActive(false);
        }

        if(playerList.ListOfPlayers.Count < 4) {
            waitingForPlayer4.SetActive(true);
            p4.SetActive(false);
            ReadyLight4.SetActive(false);
        }
        
    }

}
