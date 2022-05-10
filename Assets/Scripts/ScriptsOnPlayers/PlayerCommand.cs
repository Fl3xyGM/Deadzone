using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using NobleConnect.Mirror;

public class PlayerCommand : NetworkBehaviour {

    private PlayerManagerGame playerManagerGame;
    private PlayerListGame playerListGame;
    public int PlayerPOS;
    public bool HasBeenRun = false;

    void Update() {
        if(isLocalPlayer && SceneManager.GetActiveScene().name == "TestScene") {
            playerManagerGame = GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>();
            playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
            PlayerPOS = playerManagerGame.PlayerPOS;

            if(PlayerPOS == 1 && playerListGame.PlayerList.Count == 0 && HasBeenRun == false && this.gameObject != null) {
                CmdUpdatePlayerList(this.gameObject, PlayerPOS);
                HasBeenRun = true;
            }
            if(PlayerPOS == 2 && playerListGame.PlayerList.Count == 1 && HasBeenRun == false && this.gameObject != null) {
                CmdUpdatePlayerList(this.gameObject, PlayerPOS);
                HasBeenRun = true;
            }
            if(PlayerPOS == 3 && playerListGame.PlayerList.Count == 2 && HasBeenRun == false && this.gameObject != null) {
                CmdUpdatePlayerList(this.gameObject, PlayerPOS);
                HasBeenRun = true;
            }
            if(PlayerPOS == 4 && playerListGame.PlayerList.Count == 3 && HasBeenRun == false && this.gameObject != null) {
                CmdUpdatePlayerList(this.gameObject, PlayerPOS);
                HasBeenRun = true;
            }


        }
    }

    [Command]
    public void CmdUpdatePlayerList(GameObject player, int PlayerPOS) {
        if(GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList.Count < 5) {
            GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList.Add(player);
        }
            if(PlayerPOS == 1) {
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0] = player;
            }
            if(PlayerPOS == 2) {
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[1] = player;
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0] = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0];
            }
            if(PlayerPOS == 3) {
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[2] = player;
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0] = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0];
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[1] = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[1];
            }
            if(PlayerPOS == 4) {
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[3] = player;
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0] = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[0];
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[1] = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[1];
                GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[2] = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>().PlayerList[2];
            }
        }
}
