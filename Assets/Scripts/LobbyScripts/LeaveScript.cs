using UnityEngine;
using Mirror;

public class LeaveScript : NetworkBehaviour {
    
    public void Leave() {
        if(isServer) {
            NetworkManager.singleton.StopHost();
        }
        if(isClient) {
            NetworkManager.singleton.StopClient();
        }
    }

}
