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
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Survivor") {
            if(isServer) {
                RescuedCount += 1;
            }
            Destroy(collision.gameObject);
        }
    }
    void Update() {

        textDisplay.text = $"Survivors Rescued \n{RescuedCount} / {GameObject.FindGameObjectsWithTag("Survivor").Length}";

        if (RescuedCount == 3) {
            WinMenu.SetActive(true);
            WinMenuTriggered = true;
        }
    }
}