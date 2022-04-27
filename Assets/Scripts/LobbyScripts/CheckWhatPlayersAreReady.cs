using UnityEngine;
using Mirror;
using System.Collections.Generic;
using UnityEngine.UI;

public class CheckWhatPlayersAreReady : NetworkBehaviour {
    
    [SyncVar]
    [SerializeField] public bool Player1Ready = false;
    
    [SyncVar]
    [SerializeField] public bool Player2Ready = false;
    
    [SyncVar]
    [SerializeField] public bool Player3Ready = false;
    
    [SyncVar]
    [SerializeField] public bool Player4Ready = false;

    public GameObject StartGameButton;

    public GameObject[] ReadyLamp;

    public Sprite ReadySprite, NotReadySprite;

    public PlayerList playerList;

    public TestScript2 PlayerReadyCounter;

    private GameObject NetworkManager;

    void Update() {

        NetworkManager = GameObject.Find("NobleConnectNetworkManager");

        if(PlayerReadyCounter.ReadyCount == playerList.ListOfPlayers.Count && NetworkManager.GetComponent<NobleGUIManager>().isHost) {
            StartGameButton.SetActive(true);
        } else {
            StartGameButton.SetActive(false);
        }

        ReadyLamp = GameObject.FindGameObjectsWithTag("Lamp");
        // Make Readylight on player1 turn on if it is ready
        if(Player1Ready && playerList.ListOfPlayers.Count > 0 && ReadyLamp[0] != null) {
            ReadyLamp[0].GetComponent<Image>().sprite = ReadySprite;
        } else if(playerList.ListOfPlayers.Count > 0 && ReadyLamp[0] != null) {
            ReadyLamp[0].GetComponent<Image>().sprite = NotReadySprite;
        }

        // Make Readylight on player2 turn on if it is ready
        if(Player2Ready && playerList.ListOfPlayers.Count > 1 && ReadyLamp[1] != null) {
            ReadyLamp[1].GetComponent<Image>().sprite = ReadySprite;
        } else if(playerList.ListOfPlayers.Count > 1 && ReadyLamp.Length > 1) {
            ReadyLamp[1].GetComponent<Image>().sprite = NotReadySprite;
        }

        // Make Readylight on player3 turn on if it is ready
        if(Player3Ready && playerList.ListOfPlayers.Count > 2 && ReadyLamp[2] != null) {
            ReadyLamp[2].GetComponent<Image>().sprite = ReadySprite;
        } else if(playerList.ListOfPlayers.Count > 2 && ReadyLamp[2] != null) {
            ReadyLamp[2].GetComponent<Image>().sprite = NotReadySprite;
        }

        // Make Readylight on player4 turn on if it is ready
        if(Player4Ready && playerList.ListOfPlayers.Count > 3 && ReadyLamp[3] != null) {
            ReadyLamp[3].GetComponent<Image>().sprite = ReadySprite;
        } else if(playerList.ListOfPlayers.Count > 3 && ReadyLamp[3] != null) {
            ReadyLamp[3].GetComponent<Image>().sprite = NotReadySprite;
        }
        
        
    }
 
}
