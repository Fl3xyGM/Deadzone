using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationChooser : MonoBehaviour {

    [SerializeField] public bool Moving = false, Reloading = false, Shooting = false, DoAnims = false;
    private PlayerManagerGame playerManagerGame;
    private AnimatorHolder animatorHolder;

    void Update() {
        animatorHolder = GameObject.Find("Animators").GetComponent<AnimatorHolder>();
        
        if(SceneManager.GetActiveScene().name == "TestScene") {
            DoAnims = true;
            PlayerListGame playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();

            if(playerListGame.PlayerList.Count > 0) {
                playerListGame.PlayerList[0].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Green;
            }
            if(playerListGame.PlayerList.Count > 1) {
                playerListGame.PlayerList[1].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Blue;
            }
            if(playerListGame.PlayerList.Count > 2) {
                playerListGame.PlayerList[2].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Red;
            }
            if(playerListGame.PlayerList.Count > 3) {
                playerListGame.PlayerList[3].GetComponent<Animator>().runtimeAnimatorController = animatorHolder.Yellow;
            }

            this.GetComponent<Animator>().SetBool("Moving", Moving);
            this.GetComponent<Animator>().SetBool("Reloading", Reloading);
            this.GetComponent<Animator>().SetBool("Shooting", Shooting);
            this.GetComponent<Animator>().SetBool("DoAnims", DoAnims);

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
