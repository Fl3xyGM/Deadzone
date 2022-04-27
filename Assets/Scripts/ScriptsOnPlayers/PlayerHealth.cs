using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : NetworkBehaviour {
    
    [SyncVar]
    public int currentHealth = 100;

    private int Count = 0;
    private Slider PlayerHPSlider;
    private TextMeshProUGUI HPText;

    void Start() {
        if(SceneManager.GetActiveScene().name != "TestScene") {return;}
        if(!isLocalPlayer){return;}
        if(GameObject.Find("PlayerHPSlider").GetComponent<Slider>() != null) {
            PlayerHPSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
        }
        if(GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>() != null) {
            HPText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        }
    }

    void Update() {
        if(SceneManager.GetActiveScene().name != "TestScene") {return;}
        if(!isLocalPlayer){return;}
        PlayerHPSlider.value = currentHealth;
        HPText.text = $"{currentHealth}%";

        if(isServer) {

            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

            foreach(GameObject player in Players) {
                if(player.GetComponent<PlayerHealth>().currentHealth < 0) {
                    player.GetComponent<PlayerHealth>().currentHealth = 0;
                }
            }
        }
    }

    public void IsAttacked(GameObject PlayerObject) {
        if(isServer) {
            Count = 0;
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

            foreach(GameObject player in Players) {
                Count++;
                if(player == PlayerObject) {
                    Players[Count-1].GetComponent<PlayerHealth>().currentHealth -= 20;
                }
            }
        }
    }
}
