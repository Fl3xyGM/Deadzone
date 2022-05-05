using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class gameProgression : NetworkBehaviour {

    [SyncVar]
    [SerializeField] public int RescuedCount = 0;

    public TextMeshProUGUI textDisplay;
    public GameObject WinMenu;
    public bool WinMenuTriggered = false;
    private int MaxSurvivors;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Survivor") {
            if(isServer) {
                RescuedCount += 1;
            }
            Destroy(collision.gameObject);
        }
    }

    void Update() {

        if(MaxSurvivors == 0) {
            MaxSurvivors = GameObject.FindGameObjectsWithTag("Survivor").Length;
        }

        textDisplay.text = $"Survivors Rescued \n{RescuedCount} / {MaxSurvivors}";

        if (RescuedCount == 3) {
            WinMenu.SetActive(true);
            WinMenuTriggered = true;
        }
    }
}