using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;
public class gameProgression : NetworkBehaviour {

    [SyncVar]
    [SerializeField] public int RescuedCount = 0;

    public TextMeshProUGUI textDisplay;
    public GameObject WinMenu;
    public bool WinMenuTriggered = false;
    private int MaxSurvivors;
    private Button returnButton;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Survivor") {
            if(isServer) {
                RescuedCount += 1;
            }
            Destroy(collision.gameObject);
        }
    }
    void Start() {
        if(SceneManager.GetActiveScene().name == "TestScene") {
            returnButton = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("GameWon/Background/ReturnToStart").gameObject.GetComponent<Button>();
            returnButton.onClick.AddListener(leaveToMainMenu);
        }
    }

    void Update() {
        MaxSurvivors = GameObject.FindGameObjectsWithTag("Player").Length*3;
        

        textDisplay.text = $"Survivors Rescued \n{RescuedCount} / {MaxSurvivors}";

        if (RescuedCount == MaxSurvivors) {
            WinMenu.SetActive(true);
            WinMenuTriggered = true;
        }
        if(Input.GetKey("b")) {
            RescuedCount += 1;
        }
    }
    void leaveToMainMenu() {
        Debug.Log("This is a test");
        if(isServer) {
            NetworkManager.singleton.StopHost();
        }
        if(isClient) {
            NetworkManager.singleton.StopClient();
        }
    }
}