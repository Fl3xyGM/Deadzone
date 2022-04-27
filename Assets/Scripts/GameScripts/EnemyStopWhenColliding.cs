using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopWhenColliding : MonoBehaviour {
    

    void OnCollisionStay2D(Collision2D col) {
        if(col.collider.tag == "Player") {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnCollisionExit2D(Collision2D col) {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
