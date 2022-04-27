using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NobleGUIManager : MonoBehaviour
{
    // The NetworkManager controlled by the HUD
    NobleNetworkManager networkManager;

    // The relay ip and port from the GUI text box
    [SerializeField] public string InputIP, InputPort;

    // UI
    [SerializeField] public Button HostButton, JoinButton, ConnectButton;
    [SerializeField] public GameObject HostButtonObject, JoinButtonObject, BackButtonObject, TitleObject;
    [SerializeField] public TextMeshProUGUI IpTextFieldPlaceHolder, IpTextFieldInput, PortTextFieldPlaceHolder, PortTextFieldInput;
    [SerializeField] public TMP_InputField IpInputField, PortInputField;
    [SerializeField] public Animator AnimatorComponent;

    // Used to determine which GUI to display
    [SerializeField] public bool isHost = false;

    // IP Address and Port
    [SerializeField] public string IP;
    [SerializeField] public string Port;

    // Get a reference to the NetworkManager
    public void Start()
    {
        // Cast from Unity's NetworkManager to a NobleNetworkManager.
        networkManager = (NobleNetworkManager)NetworkManager.singleton;

        // Set button Events
        HostButton.onClick.AddListener(HostGame);
        JoinButton.onClick.AddListener(JoinGame);
        ConnectButton.onClick.AddListener(ConnectToHost);
    }

    void HostGame() {
        isHost = true;
        networkManager.StartHost();
    }

    void JoinGame() {
        AnimatorComponent.SetBool("ClientAnimation", true);
        HostButtonObject.SetActive(false);
        JoinButtonObject.SetActive(false);
        BackButtonObject.SetActive(false);
        TitleObject.SetActive(false);
        networkManager.InitClient();
    }

    void ConnectToHost() {
        networkManager.networkAddress = InputIP;
        networkManager.networkPort = ushort.Parse(InputPort);
        networkManager.StartClient();
    }

    void Update() {
        if(networkManager.HostEndPoint != null) {
            IP = networkManager.HostEndPoint.Address.ToString();
            Port = networkManager.HostEndPoint.Port.ToString();
        }
        if(!isHost && SceneManager.GetActiveScene().name == "MainScreen") {
            InputIP = IpInputField.text;
            InputPort = PortInputField.text;
        }
    }
}
