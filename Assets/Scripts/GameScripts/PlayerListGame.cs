using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;

public class PlayerListGame : NetworkBehaviour {

    public readonly SyncList<GameObject> PlayerList = new SyncList<GameObject>();

}
