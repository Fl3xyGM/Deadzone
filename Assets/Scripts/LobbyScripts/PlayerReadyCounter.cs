using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerReadyCounter : MonoBehaviour {
    
    [SerializeField] public TextMeshProUGUI ReadyText;

    [SerializeField] public PlayerList playerList;

    [SerializeField] public TestScript2 PlayersReady;
    void Update() {
        if(PlayersReady.ReadyCount == playerList.ListOfPlayers.Count) {
            ReadyText.text = $"<color=green>Players Ready</color>\n{PlayersReady.ReadyCount}/{playerList.ListOfPlayers.Count}";
        } else {
            ReadyText.text = $"<color=red>Players Ready</color>\n{PlayersReady.ReadyCount}/{playerList.ListOfPlayers.Count}";
        }
    }
}
