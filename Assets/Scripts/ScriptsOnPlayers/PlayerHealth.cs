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
        CmdHealPlayer(GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>().PlayerPOS);
        IsDead = false;
        GameObject.Find("Main Camera").transform.Find("HealthBar").gameObject.SetActive(true);
        GameObject.Find("Main Camera").transform.Find("AmmoCounter").gameObject.SetActive(true);
        GameObject.Find("Main Camera").transform.Find("SurvivorsRescued").gameObject.SetActive(true);
    }

    [Command]
    public void CmdHealPlayer(int PlayerPOS) {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        if(PlayerPOS == 1) {
            Players[0].GetComponent<PlayerHealth>().currentHealth = 100;
        }
        if(PlayerPOS == 2) {
            Players[1].GetComponent<PlayerHealth>().currentHealth = 100;
        }
        if(PlayerPOS == 3) {
            Players[2].GetComponent<PlayerHealth>().currentHealth = 100;
        }
        if(PlayerPOS == 4) {
            Players[3].GetComponent<PlayerHealth>().currentHealth = 100;
        }
    }

    public void IsAttacked(GameObject PlayerObject) {
            GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
            Count = 0;
            foreach(GameObject player in Players) {
                Count++;
                if(player == PlayerObject) {
                    if(isServer) {
                        Players[Count-1].GetComponent<PlayerHealth>().currentHealth -= 20;
                    }
                }
            }
        if (isLocalPlayer && currentHealth <= 0) {
            transform.position = new Vector3(-100, -80, transform.position.z);
            respawnMenu.SetActive(true);
            CountDown = true;
            PlayerGettingHealed = Players[Count-1];
            IsDead = true;
            GameObject.Find("Main Camera").transform.Find("HealthBar").gameObject.SetActive(false);
            GameObject.Find("Main Camera").transform.Find("AmmoCounter").gameObject.SetActive(false);
            GameObject.Find("Main Camera").transform.Find("SurvivorsRescued").gameObject.SetActive(false);
        }
    }
}