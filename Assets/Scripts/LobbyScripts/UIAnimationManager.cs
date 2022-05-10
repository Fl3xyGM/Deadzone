using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimationManager : MonoBehaviour {
    
    [SerializeField] public Animator PlayAnimator, HelpAnimator, QuitAnimator, back2, join2, HostAnimator, JoinAnimator, BackAnimator, helpPanel;
    private bool openHelp = false, play = false;
    public GameObject host, join, back, title;
    // UI Left
    public void UILeft() {
        play = true;
        PlayAnimator.SetBool("Left", true);
        PlayAnimator.SetBool("Right", false);
        HelpAnimator.SetBool("Left", true);
        HelpAnimator.SetBool("Right", false);
        QuitAnimator.SetBool("Left", true);
        QuitAnimator.SetBool("Right", false);
        HostAnimator.SetBool("Left", true);
        HostAnimator.SetBool("Right", false);
        JoinAnimator.SetBool("Left", true);
        JoinAnimator.SetBool("Right", false);
        BackAnimator.SetBool("Left", true);
        BackAnimator.SetBool("Right", false);
    }

    // UI Right
    public void UIRight() {
        if (play == true) {
            PlayAnimator.SetBool("Left", false);
            PlayAnimator.SetBool("Right", true);
            HelpAnimator.SetBool("Left", false);
            HelpAnimator.SetBool("Right", true);
            QuitAnimator.SetBool("Left", false);
            QuitAnimator.SetBool("Right", true);
            HostAnimator.SetBool("Left", false);
            HostAnimator.SetBool("Right", true);
            JoinAnimator.SetBool("Left", false);
            JoinAnimator.SetBool("Right", true);
            BackAnimator.SetBool("Left", false);
            BackAnimator.SetBool("Right", true);
        }
        if (openHelp == true) {
            openHelp = false;
            PlayAnimator.SetBool("Left", false);
            HelpAnimator.SetBool("Left", false);
            QuitAnimator.SetBool("Left", false);
            BackAnimator.SetBool("Left", false);
            PlayAnimator.SetBool("Right", true);
            HelpAnimator.SetBool("Right", true);
            QuitAnimator.SetBool("Right", true);
            BackAnimator.SetBool("Right", true);
            helpPanel.SetBool("active", false);
        }
    }
    public void openHelpMenu() {
        openHelp = true;
        PlayAnimator.SetBool("Right", false);
        HelpAnimator.SetBool("Right", false);
        QuitAnimator.SetBool("Right", false);
        BackAnimator.SetBool("Right", false);
        PlayAnimator.SetBool("Left", true);
        HelpAnimator.SetBool("Left", true);
        QuitAnimator.SetBool("Left", true);
        BackAnimator.SetBool("Left", true);
        helpPanel.SetBool("active", true);
    }
    public void returnToMain() {
        if (back2.GetBool("active") == true) {
            back2.SetBool("active", false);
            join2.SetBool("ClientAnimation", false);
            StartCoroutine(waitForSeconds());
        }
    }
    IEnumerator waitForSeconds() {
        yield return new WaitForSeconds(0.75f);
        host.SetActive(true);
        join.SetActive(true);
        back.SetActive(true);
        title.SetActive(true);
    }
}