using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class helpMenuScript : MonoBehaviour
{
    public TextMeshProUGUI title, breadText;
    public void controlPanel() {
        title.text = "CONTROLS";
        breadText.text = "W - Move Up\nS - Move Down             Shoot - Left Mouse Button\nA - Move Left\nD - Move Right";
    }
    public void goalPanel() {
        title.text = "Main Goal";
        breadText.text = "blah";
    }
}
