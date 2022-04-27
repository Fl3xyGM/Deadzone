using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class testScript : NetworkBehaviour {
    
    private Button ReadyButton;
    private TextMeshProUGUI ReadyButtonText;
    void Awake() {
        if(SceneManager.GetActiveScene().name == "Lobby") {
            ReadyButton = GameObject.Find("Ready").GetComponent<Button>();
            ReadyButtonText = ReadyButton.GetComponentInChildren<TextMeshProUGUI>();
            ReadyButton.onClick.AddListener(Count);
        }
    }

    void Count() {
        if(isLocalPlayer) {
            if(ReadyButtonText.text == "<color=green>Ready</color>") {
                int Playerpos = GameObject.Find("PlayerManager").GetComponent<PlayerData>().PlayerPOS;
                CmdCountUp(GameObject.Find("GameControllerTest"), GameObject.Find("ReadyManager"), Playerpos);
                ReadyButtonText.text = "<color=red>Cancel</color>";
            } else if(ReadyButtonText.text == "<color=red>Cancel</color>") {
                int Playerpos = GameObject.Find("PlayerManager").GetComponent<PlayerData>().PlayerPOS;
                CmdCountDown(GameObject.Find("GameControllerTest"), GameObject.Find("ReadyManager"), Playerpos);
                ReadyButtonText.text = "<color=green>Ready</color>";
            }
        }
    }


    [Command]
    public void CmdCountUp(GameObject GameController, GameObject ReadyManager, int PlayerPOS) {
        GameController.GetComponent<TestScript2>().ReadyCount += 1;
        if(PlayerPOS == 1) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player1Ready = true;
        } else if(PlayerPOS == 2) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player2Ready = true;
        } else if(PlayerPOS == 3) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player3Ready = true;
        } else if(PlayerPOS == 4) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player4Ready = true;
        }
    }

    [Command]
    public void CmdCountDown(GameObject GameController, GameObject ReadyManager, int PlayerPOS) {
        GameController.GetComponent<TestScript2>().ReadyCount -= 1;
        if(PlayerPOS == 1) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player1Ready = false;
        } else if(PlayerPOS == 2) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player2Ready = false;
        } else if(PlayerPOS == 3) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player3Ready = false;
        } else if(PlayerPOS == 4) {
            ReadyManager.GetComponent<CheckWhatPlayersAreReady>().Player4Ready = false;
        }
    }


}
