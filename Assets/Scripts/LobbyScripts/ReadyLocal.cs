using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadyLocal : MonoBehaviour {
    
    public ReadyStartScript ReadyServer;
    public LobbyUI Lobby;
    public TextMeshProUGUI ReadyText;
    public Button ReadyButton;
    private bool ButtonPressed = false;



    public void ReadyPrivateFunction() {
        if(ButtonPressed == false) {
            ReadyButton.enabled = false;
            ButtonPressed = true;
        }
    }

    void Update() {

        if(ButtonPressed) {
            //ReadyText.text = $"{ReadyServer.ReadyUP}/{Lobby.PlayersConnected}";
        }

    }


}
