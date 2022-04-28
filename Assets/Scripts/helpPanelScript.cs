using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class helpPanelScript : MonoBehaviour
{
    public TextMeshProUGUI helpText;
    public void Controls() {
        helpText.text = "W - Move Up\nS - Move down                Shoot - Left Mouse Button\nA - Move Left\nD - Move Right";
    }
    public void Gameplay() {
        helpText.text = "Your mission is  to rescue abandonded survivors!\nBe careful not to die to the hands of the zombies!\nYou can shoot the zombies\nAfter finding a suvivor return to the safe zone!";
    }
}
