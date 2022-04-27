using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class enemyRotation : NetworkBehaviour
{
    State zombieState;
    private AImovement AImovement;
    [Server]
    void Start() {
        AImovement = gameObject.GetComponent<AImovement>();
    }
    [Server]
    void Update()
    {
        if (zombieState == State.ChasePlayer) {
            Vector3 direction2 = AImovement.target.transform.position - transform.position;
            float angle2 = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
            AImovement.rb.rotation = angle2;
        }     
    }
}
