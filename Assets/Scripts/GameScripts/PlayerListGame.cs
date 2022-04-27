using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;

public class PlayerListGame : NetworkBehaviour {

    public readonly SyncList<GameObject> PlayerList = new SyncList<GameObject>();

// '    [SerializeField] public Vector3 PlayerPos1, PlayerPos2, PlayerPos3, PlayerPos4;

//     void Update() {
//         if(PlayerList.Count > 0) {
//             PlayerPos1 = PlayerList[0].transform.position;
//         }
//         if(PlayerList.Count > 1) {
//             PlayerPos2 = PlayerList[1].transform.position;

//         }
//         if(PlayerList.Count > 2) {
//             PlayerPos3 = PlayerList[2].transform.position;

//         }
//         if(PlayerList.Count > 3) {
//             PlayerPos4 = PlayerList[3].transform.position;

//         }
//     }'

}
