using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathSound : MonoBehaviour {
    
    [SerializeField]
    public bool DeathSound = false;

    void Update() {

        if(DeathSound) {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
            DeathSound = false;
        }
        
    }
}
