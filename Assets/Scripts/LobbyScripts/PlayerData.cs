using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerData : NetworkBehaviour {

    [SerializeField]
    public int PlayerPOS = 0;

    [SerializeField]
    public GameObject ClientPlayerObject;

    private GameObject playerManager;

    private List<GameObject> LocalList = new List<GameObject>();

    void Update() {

        playerManager = GameObject.Find("PlayerManager");

        if(PlayerPOS == 0) {
            PlayerPOS = playerManager.GetComponent<PlayerList>().ListOfPlayers.Count;
            LocalList = playerManager.GetComponent<PlayerList>().ListOfPlayers;
        }
        if(ClientPlayerObject == null && PlayerPOS != 0) {
            ClientPlayerObject = playerManager.GetComponent<PlayerList>().ListOfPlayers[PlayerPOS-1];
        }

        if(LocalList.Count != playerManager.GetComponent<PlayerList>().ListOfPlayers.Count) {
            LocalList = playerManager.GetComponent<PlayerList>().ListOfPlayers;

            for(int i = 0; i < LocalList.Count; i++) {
                if(ClientPlayerObject == LocalList[i]) {
                    PlayerPOS = i+1;
                }
            }

        }

        PlayerPrefs.SetInt("PlayerPOS", PlayerPOS);

    }

}
