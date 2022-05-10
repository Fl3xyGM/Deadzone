using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class AnimationChooser : NetworkBehaviour {

    [SerializeField] public bool Moving = false, Reloading = false, Shooting = false, DoAnims = false;
    private PlayerManagerGame playerManagerGame;
    private AnimatorHolder animatorHolder;
    private bool IsRun1 = false, IsRun2 = false, IsRun3 = false, IsRun4 = false;

    void Update() {
        animatorHolder = GameObject.Find("Animators").GetComponent<AnimatorHolder>();
        
        if(SceneManager.GetActiveScene().name == "TestScene") {
            if(!isLocalPlayer){return;}
            DoAnims = true;
            this.GetComponent<Animator>().SetBool("DoAnims", DoAnims);
            PlayerListGame playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();

            if(playerListGame.PlayerList[0] == null) {
                playerListGame.PlayerList[0].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Green;
            }

            if(playerListGame.PlayerList.Count > 0 && !IsRun1) {
                playerListGame.PlayerList[0].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Green;
                IsRun1 = true;
            }
            if(playerListGame.PlayerList.Count > 1 && !IsRun2) {
                playerListGame.PlayerList[1].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Blue;
                IsRun2 = true;
            }
            if(playerListGame.PlayerList.Count > 2 && !IsRun3) {
                playerListGame.PlayerList[2].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Red;
                IsRun3 = true;
            }
            if(playerListGame.PlayerList.Count > 3 && !IsRun4) {
                playerListGame.PlayerList[3].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Yellow;
                IsRun4 = true;
            }

            if(isLocalPlayer) {
                this.GetComponent<Animator>().SetBool("Moving", Moving);
                this.GetComponent<Animator>().SetBool("Reloading", Reloading);
                this.GetComponent<Animator>().SetBool("Shooting", Shooting);
            }

        }

        if(SceneManager.GetActiveScene().name == "Lobby") {
            PlayerList playerList = GameObject.Find("PlayerManager").GetComponent<PlayerList>();

            if(playerList.ListOfPlayers.Count > 0) {
                playerList.ListOfPlayers[0].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Green;
            }
            if(playerList.ListOfPlayers.Count > 1) {
                playerList.ListOfPlayers[1].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Blue;
            }
            if(playerList.ListOfPlayers.Count > 2) {
                playerList.ListOfPlayers[2].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Red;
            }
            if(playerList.ListOfPlayers.Count > 3) {
                playerList.ListOfPlayers[3].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Yellow;
            }

        }

    }
}
