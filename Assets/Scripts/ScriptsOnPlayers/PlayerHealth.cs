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

    private int Count = 0, respawnTimer = 0, frameCounter;
    private Slider PlayerHPSlider;
    private TextMeshProUGUI HPText, respawnText;
    private GameObject respawnMenu, respawnButton;
    private Button respawnButtonButton;
    private bool CountDown = false;
    private GameObject PlayerGettingHealed;
    public bool IsDead = false;

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
        respawnMenu = GameObject.Find("Main Camera").transform.Find("RespawnMenu").gameObject;
        respawnButton = respawnMenu.transform.Find("MenuBackground/RespawnButton").gameObject;
        respawnButtonButton = respawnButton.GetComponent<Button>();
        respawnText = respawnMenu.transform.Find("MenuBackground/RespawnText").GetComponent<TextMeshProUGUI>();
        respawnButtonButton.onClick.AddListener(Respawn);
        if(CountDown) {
            frameCounter++;
            respawnText.text = "You can respawn in " + $"{respawnTimer}";
            respawnTimer = 5-(frameCounter/60);   
            if(respawnTimer <= 0 && frameCounter > 300) {
                respawnButton.SetActive(true);
                frameCounter = 0;
                CountDown = false;
            }
        }
        
        if(isServer) {

            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

            foreach(GameObject player in Players) {
                if(player.GetComponent<PlayerHealth>().currentHealth < 0) {
                    player.GetComponent<PlayerHealth>().currentHealth = 0;
                }
            }
        }
    }
    void Respawn() {
        transform.position = new Vector3(4, -90, transform.position.z);
        respawnMenu.SetActive(false);
        respawnButton.SetActive(false);
        PlayerGettingHealed.GetComponent<PlayerHealth>().currentHealth = 100;
        IsDead = false;
        GameObject.Find("Main Camera").transform.Find("HealthBar").gameObject.SetActive(true);
        GameObject.Find("Main Camera").transform.Find("AmmoCounter").gameObject.SetActive(true);
        GameObject.Find("Main Camera").transform.Find("SurvivorsRescued").gameObject.SetActive(true);
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
            if (Players[Count-1].GetComponent<PlayerHealth>().currentHealth == 0) {
                transform.position = new Vector3(-100, -80, transform.position.z);
                respawnMenu.SetActive(true);
                CountDown = true;
                PlayerGettingHealed = Players[Count-1];
                IsDead = true;
                GameObject.Find("Main Camera").transform.Find("HealthBar").gameObject.SetActive(false);
                GameObject.Find("Main Camera").transform.Find("AmmoCounter").gameObject.SetActive(false);
                GameObject.Find("Main Camera").transform.Find("SurvivorsRescued").gameObject.SetActive(false);
            }
            // if (respawnTimer == 0) {
            //     respawnButton.SetActive(true);
            // }
        }
    }
}