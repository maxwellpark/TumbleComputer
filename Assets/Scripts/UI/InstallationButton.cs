using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// could change buttons to toggles, then when one is
// pressed, toggle off all the others
// (or at least the currently on toggle)
// 
// explain the need for this script and the Manager script 
// separation of concerns/easier to get references*
public class InstallationButton : MonoBehaviour
{
    // The prefab of the component installed by this button
    [SerializeField] private GameObject componentPrefab; 

    // The buttons that comprise the installation menu 
    [SerializeField] private Button[] buttons;

    [SerializeField] private InstallationButton[] installationButtons; 

    // The button component attached to the GameObject that 
    // this script is attached to 
    private Button button;

    private bool selected; 
        
    private void Start()
    {
        button = GetComponent<Button>();
        AddListener(); 
    }

    private void AddListener()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { ButtonHandler(); });
    }

    public void SetAllButtonsInteractable()
    {
        // change to exclude clicked btn?
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void DeselectAllButtons()
    {
        foreach (InstallationButton _installationButton in installationButtons)
        {
            _installationButton.selected = false;
            ChangeButtonColour(_installationButton.GetComponent<Button>(), MachineConstants.buttonDeselectedColour);
        }
    }

    public void ResetAlphaValues()
    {
        foreach (Button _button in buttons)
        {
            _button.GetComponent<Image>().color = MachineConstants.buttonDeselectedColour;
        }
    }

    private void ChangeButtonColour(Button _button, Color _color)
    {
        _button.GetComponent<Image>().color = _color; 
    }

    public void ReduceButtonOpacity()
    {
        Image buttonImage = button.GetComponent<Image>();
        //Color newColor = buttonImage.color;
        Color color = new Color(0f, 0f, 01f, 50f);
        buttonImage.color = color; 
        Debug.Log("Selected alppha = " + buttonImage.color.a);
    }

    // rename to HandleButtonPress (act/deact combined) 
    // or have separate Activate and Deactivate methods 
    // and put inside a handler method 
    private void ButtonHandler()
    {
        //    Debug.Log("ButtonHandler");
        //    Debug.Log("Selected: " + selected);
        //SetAllButtonsInteractable();
        //button.interactable = false;

        if (!selected)
        {
            Debug.Log("!selected, deselecting and changingbutton colour"); 
            selected = true;
            DeselectAllButtons();
            ChangeButtonColour(button, MachineConstants.buttonSelectedColour); 
            InstallationManager.installing = true;
            InstallationManager.selectedPrefab = componentPrefab;
        }
        else
        {
            Debug.Log("selected, deselecting all"); 
            DeselectAllButtons(); 
            InstallationManager.installing = false;

            // set to null or just leave as is? 
            //InstallationManager.selectedPrefab = componentPrefab;
        }

        Debug.Log("Selected: " + selected);

        //if (button.interactable)
        //{
        //    Debug.Log("Making interactable again"); 
        //    button.interactable = true; 
        //    InstallationManager.installing = false;
        //}
    }
}
