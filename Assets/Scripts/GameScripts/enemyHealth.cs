using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class enemyHealth : NetworkBehaviour
{
    public int maxHealth = 100;
    [SyncVar]
    public int currentHealth;
    public Slider slider;
    void Awake() {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
    }
    private void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }
    private void SetHealth(int health) {
        slider.value = health;
    }
    
    void Update() {

        SetHealth(currentHealth);

        if (currentHealth < 1 && isServer) {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D bullet) {
        if (bullet.tag == "Bullet") {
            if(isServer) {
                currentHealth -= 20;
                Destroy(bullet.gameObject);
            }
            SetHealth(currentHealth);
        }
    }
}
