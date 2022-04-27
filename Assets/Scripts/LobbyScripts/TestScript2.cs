using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestScript2 : NetworkBehaviour {
    
    [SyncVar]
    [SerializeField] public int ReadyCount = 0;
}