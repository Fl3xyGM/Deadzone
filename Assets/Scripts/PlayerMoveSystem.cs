using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMoveSystem : NetworkBehaviour {

    Rigidbody2D ThisPlayersRB;

    void Start() {
        ThisPlayersRB = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(!isLocalPlayer) {return;}
        if(SceneManager.GetActiveScene().name != "TestScene") {return;}

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * 5f * Time.deltaTime;
        ThisPlayersRB.MovePosition(transform.position + tempVect*2);
    }


}
