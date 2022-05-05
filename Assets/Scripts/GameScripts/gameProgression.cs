using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class gameProgression : NetworkBehaviour
{
    private int RescuedCount = 0;
    public TextMeshProUGUI textDisplay;
    public GameObject WinMenu;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Survivor") {
            RescuedCount += 1;
            Destroy(collision.gameObject);
            textDisplay.text = "Survivors Rescued " + RescuedCount;
        }
    }
    void Update() {
        if (RescuedCount == 3) {
            WinMenu.SetActive(true);
            // Set Player movement and game to null
        }
    }
}