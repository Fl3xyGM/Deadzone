using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TargetChooser : NetworkBehaviour {
    
    private int PlayerTarget;
    private bool IsCloseEnough;
    private float DistanceFromTarget;
    private Vector3 CurrentPosition;
    public GameObject Target;
    private PlayerListGame playerListGame;

    [Server]
    void Update() {
        playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
        CurrentPosition = transform.position;

        DistanceFromTarget = 10;
        IsCloseEnough = false;
        for(int i = 0; i < playerListGame.PlayerList.Count; i++) {
            float distance = Vector2.Distance(CurrentPosition, playerListGame.PlayerList[i].transform.position);
            if(DistanceFromTarget > distance) {
                PlayerTarget = i;
                DistanceFromTarget = distance;
                IsCloseEnough = true;
            }
        }

        if(IsCloseEnough) {
            Target = playerListGame.PlayerList[PlayerTarget];
        }


    }



}
