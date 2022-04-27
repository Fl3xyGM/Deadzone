using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Limiter : MonoBehaviour {
    void Start() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        
    }
}
