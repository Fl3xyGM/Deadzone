using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NobleConnect.Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class BulletSpawn : NetworkBehaviour {
    
    [SerializeField] public GameObject BulletPrefab;

    private PlayerListGame playerListGame;
    private PlayerManagerGame playerManagerGame;
    private int CurrentBullets = 10;
    public Sprite BlackBox, RedBox;

    private bool CanAttack = true;
    private int Cooldown = 0;
    private bool IsReloading = false;

    void Update() {
            if(SceneManager.GetActiveScene().name != "TestScene") {return;}
            if(GetComponent<LeaveGameScript>().IsActive || GameObject.Find("SafeZone").GetComponent<gameProgression>().WinMenuTriggered) {return;}
            if(isLocalPlayer) {

                if(!CanAttack && IsReloading == false) {
                Cooldown++;
                if(Cooldown == 10) {
                    CanAttack = true;
                    Cooldown = 0;
                }
            }


            playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
            playerManagerGame = GameObject.Find("PlayerManager").GetComponent<PlayerManagerGame>();
            if(playerListGame == null) {return;}
            if(Input.GetKey("r")) {
                StartCoroutine(Wait2());
                GetComponent<AnimationChooser>().Shooting = false;
                GetComponent<AnimationChooser>().Reloading = true;
                IsReloading = true;
            }
            if(CurrentBullets <= 0) {
                GameObject.Find("CurrentAmmo").GetComponent<TextMeshProUGUI>().text = $"<color=red>{CurrentBullets}</color>";
                GameObject.Find("AmmoBox").GetComponent<SpriteRenderer>().sprite = RedBox;
                return;
            } else {
                GameObject.Find("CurrentAmmo").GetComponent<TextMeshProUGUI>().text = $"<color=black>{CurrentBullets}</color>";
                GameObject.Find("AmmoBox").GetComponent<SpriteRenderer>().sprite = BlackBox;
            }
            if(Input.GetMouseButton(0) && CanAttack) {
                if(playerListGame.PlayerList.Count > 0) {
                    if(GetComponent<AnimationChooser>().Reloading == false) {
                        GetComponent<AnimationChooser>().Moving = false;
                        GetComponent<AnimationChooser>().Shooting = true;
                    }
                    CanAttack = false;
                    CurrentBullets--;
                    Vector3 BulletSpawn = playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.Find("ShootPoint").transform.position;
                    Quaternion Rotation = playerListGame.PlayerList[playerManagerGame.PlayerPOS-1].transform.localRotation;
                    CmdSpawnBullet(BulletSpawn, Rotation, playerManagerGame.PlayerPOS);
                    GetComponent<AudioSource>().Play();
                    StartCoroutine(Wait1());
                }
            }



        }
    }

    IEnumerator Wait1() {
        yield return new WaitForSeconds(0.2f);
        GetComponent<AnimationChooser>().Shooting = false;
    }

    IEnumerator Wait2() {
        CanAttack = false;
        yield return new WaitForSeconds(1.76f);
        GetComponent<AnimationChooser>().Reloading = false;
        CurrentBullets = 10;
        yield return new WaitForSeconds(0.1f);
        IsReloading = false;
        Cooldown = 0;
    }





    [Command]
    public void CmdSpawnBullet(Vector3 SpawnPosition, Quaternion Rotation, int PlayerPos) {
        PlayerListGame playerListGame = GameObject.Find("PlayerManager").GetComponent<PlayerListGame>();
        SpawnPosition = playerListGame.PlayerList[PlayerPos-1].transform.Find("ShootPoint").transform.position;
        Rotation = playerListGame.PlayerList[PlayerPos-1].transform.localRotation;
        GameObject Prefab = Instantiate(BulletPrefab, SpawnPosition, Rotation);
        Destroy(Prefab, 1f);
        NetworkServer.Spawn(Prefab);
    }



}
