using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour {
    
    [SerializeField] public Animator PlayAnimator, HelpAnimator, QuitAnimator, HostAnimator, JoinAnimator, BackAnimator, helpPanel;
    private bool openHelp = false, play = false;
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

    // UI Left
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
}