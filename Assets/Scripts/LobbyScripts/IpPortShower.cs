using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IpPortShower : MonoBehaviour {    
    
    [SerializeField] public TextMeshProUGUI TextField;
    [SerializeField] public GameObject Canvas;
    
    private NobleGUIManager nobleGUIManager;

    void Update() {

        nobleGUIManager = GameObject.Find("NobleConnectNetworkManager").GetComponent<NobleGUIManager>();

        if(nobleGUIManager.isHost) {
            Canvas.SetActive(true);
        }

        if(nobleGUIManager != null) {
            TextField.text = $"IP: {nobleGUIManager.IP} \nPort: {nobleGUIManager.Port}";    
        }
    }
}
