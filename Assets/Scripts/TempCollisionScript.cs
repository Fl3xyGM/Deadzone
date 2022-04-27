using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCollisionScript : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>().PlayerObject) {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject == GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>().PlayerObject) {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
