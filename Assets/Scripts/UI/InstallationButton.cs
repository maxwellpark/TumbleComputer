using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        Color color = new Color(0f, 0f, 01f, 50f);
        buttonImage.color = color; 
        Debug.Log("Selected alppha = " + buttonImage.color.a);
    }

    private void ButtonHandler()
    {
        Debug.Log("Selected = " + selected);
        //if (!selected)
        //{
        //    Debug.Log("!selected, deselecting and changingbutton colour"); 
        //    DeselectAllButtons();
        //    selected = true;
        //    ChangeButtonColour(button, MachineConstants.buttonSelectedColour); 
        //    InstallationManager.installing = true;
        //    InstallationManager.selectedPrefab = componentPrefab;
        //}
        //else
        //{
        //    Debug.Log("selected, deselecting all"); 
        //    DeselectAllButtons();
        //    InstallationManager.installing = false;
        //}
        DeselectAllButtons();
        selected = true;
        InstallationManager.selectedPrefab = componentPrefab;
        InstallationManager.installing = true; 

    }
}
