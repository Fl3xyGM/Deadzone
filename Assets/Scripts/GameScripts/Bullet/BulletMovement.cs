using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private int timer = 0;

    void Update() {
        Vector3 Forward = transform.right;
        transform.position += new Vector3(Forward.x, Forward.y, transform.position.z) * (25f * Time.deltaTime);
        if(timer < 2) {
            timer++;
        }
    }


    void OnTriggerEnter2D(Collider2D col) {
        if(timer < 2) {return;}
        if(col.name == "SafeZone") {return;}
        Debug.Log("Hello");
        Destroy(this.gameObject);
    }

}
