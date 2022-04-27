using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class PlayerList : NetworkBehaviour {
    
    public List<GameObject> ListOfPlayers = new List<GameObject>();
    
    [SerializeField]
    public Vector3 PlayerPosition;

    private PlayerData playerData;

    [SerializeField] public Sprite Player1Sprite, Player2Sprite, Player3Sprite, Player4Sprite;

    void Update() {
        ListOfPlayers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        playerData = GameObject.Find("PlayerManager").GetComponent<PlayerData>();
        if(playerData.PlayerPOS != 0) {
            PlayerPosition = ListOfPlayers[playerData.PlayerPOS-1].transform.position;
        }

        if(ListOfPlayers.Count > 0) {
            ListOfPlayers[0].GetComponent<SpriteRenderer>().sprite = Player1Sprite;
            ListOfPlayers[0].transform.position = new Vector3(-5.70f, 1.4f, 0);
        }
        if(ListOfPlayers.Count > 1) {
            ListOfPlayers[1].GetComponent<SpriteRenderer>().sprite = Player2Sprite;
            ListOfPlayers[1].transform.position = new Vector3(-2.02f, 1.4f, 0);

        }
        if(ListOfPlayers.Count > 2) {
            ListOfPlayers[2].GetComponent<SpriteRenderer>().sprite = Player3Sprite;
            ListOfPlayers[2].transform.position = new Vector3(2.02f, 1.4f, 0);

        }
        if(ListOfPlayers.Count > 3) {
            ListOfPlayers[3].GetComponent<SpriteRenderer>().sprite = Player4Sprite;
            ListOfPlayers[3].transform.position = new Vector3(5.70f, 1.4f, 0);

        }

    }

}
