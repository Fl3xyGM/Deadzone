using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGameScript : MonoBehaviour
{
    public GameObject menu;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
    }
    public void LeaveGame() {
        Application.Quit();
    }
    public void dontLeave() {
        menu.SetActive(false);
    }
}
