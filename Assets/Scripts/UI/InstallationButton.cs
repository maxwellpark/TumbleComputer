using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// could change buttons to toggles, then when one is
// pressed, toggle off all the others
// (or at least the currently on toggle)
// 
public class InstallationButton : MonoBehaviour
{

    // The buttons that comprise the installation menu 
    [SerializeField] private Button[] buttons;

    public void SetAllButtonsInteractable()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == -1)
            return;

        SetAllButtonsInteractable();

        clickedButton.interactable = false;
    }
}
