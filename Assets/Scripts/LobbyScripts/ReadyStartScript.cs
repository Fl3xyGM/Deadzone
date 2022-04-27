using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ReadyStartScript : NetworkBehaviour {
    
    public bool IsReady = false;
    [SerializeField] public TextMeshProUGUI ButtonText;
    [SerializeField] public Button Button;

    // private GameObject[] playerList;
    // private int ReadyValue;

    // private PlayerData playerData;

    // void Update() {
    //     playerData = GameObject.Find("PlayerManager").GetComponent<PlayerData>();
    //     playerList = GameObject.FindGameObjectsWithTag("Player");
    //     ReadyValue = playerList[playerData.PlayerPOS].GetComponent<PlayerCommand>().ReadyUpValue;
    //     Debug.Log(playerList[playerData.PlayerPOS].GetComponent<PlayerCommand>().ReadyUpValue);
    //     if(IsReady) {
    //         ButtonText.text = $"{ReadyValue}/{playerList.Length}";
    //     }
    // }

    public void ReadyButton() {
        IsReady = true;
        Button.enabled = false;
    }

}
