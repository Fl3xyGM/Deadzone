using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : MonoBehaviour
{
    void Update() {
        // if (!isLocalPlayer) { return; }

        float moveX = Input.GetAxis("Horizontal") + Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") + Time.deltaTime * 4f;

        transform.Rotate(0, moveX, 0);
        transform.Rotate(0, 0, moveZ);
    }
}
