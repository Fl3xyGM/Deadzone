using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class gameProgression : NetworkBehaviour
{
    private int RescuedCount = 0;
    // public TextMeshProUGUI textDisplay;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Survivor") {
            RescuedCount += 1;
            Destroy(GameObject.FindWithTag("Survivor"));
            // textDisplay.text = "Survivors Rescued " + RescuedCount;
        }
    }
}