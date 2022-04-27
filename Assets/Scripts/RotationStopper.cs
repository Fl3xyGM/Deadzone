using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStopper : MonoBehaviour {
    

    void LateUpdate() {
        transform.rotation = Quaternion.Euler(0f, 0f, -transform.parent.rotation.z);
    }
}
