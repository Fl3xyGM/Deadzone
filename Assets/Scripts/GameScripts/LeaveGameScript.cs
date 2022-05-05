using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaveGameScript : MonoBehaviour
{
    private GameObject menu;
    private Button Yes, No;
    public bool IsActive = false;

    void Start() {
        if(SceneManager.GetActiveScene().name == "TestScene") {
            menu = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("EscapeMenu").gameObject;
            Yes = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("EscapeMenu/MenuBackground/yes").gameObject.GetComponent<Button>();
            No = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("EscapeMenu/MenuBackground/No").gameObject.GetComponent<Button>();
            Yes.onClick.AddListener(LeaveGame);
            No.onClick.AddListener(dontLeave);
        }
    }

    void Update() {
        if(SceneManager.GetActiveScene().name == "TestScene") {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if(!IsActive) {
                    StartCoroutine(SetActiveTrue());
                }
                if(IsActive) {
                    StartCoroutine(SetActiveFalse());
                }
            }
        }
    }

    IEnumerator SetActiveTrue() {
        yield return new WaitForSeconds(0.2f);
        menu.SetActive(true);
        IsActive = true;
    }
    IEnumerator SetActiveFalse() {
        yield return new WaitForSeconds(0.2f);
        menu.SetActive(false);
        IsActive = false;
    }


    public void LeaveGame() {
        Application.Quit();
    }
    public void dontLeave() {
        menu.SetActive(false);
        IsActive = false;
    }
}
