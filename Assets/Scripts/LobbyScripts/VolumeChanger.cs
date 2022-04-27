using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour {
    
    public Slider VolumeSlider;

    void Start() {
        VolumeSlider.value = PlayerPrefs.GetFloat("VolumeSlider");
    }

    void Update() {
        PlayerPrefs.SetFloat("VolumeSlider", VolumeSlider.value);
        GetComponent<AudioSource>().volume = VolumeSlider.value;
        
    }
}
