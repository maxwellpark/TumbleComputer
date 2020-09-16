using System;
using System.Collections;
using System.Collections.Generic;
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

    // The button component attached to the GameObject that 
    // this script is attached to 
    private Button button;
        
    private void Start()
    {
        button = GetComponent<Button>();
        AddListener(); 
    }

    private void AddListener()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { ActivateButton(); });
    }
    // AM 
    public void SetAllButtonsInteractable()
    {
        // change to exclude clicked btn?
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    // rename to HandleButtonPress (act/deact combined) 
    // or have separate Activate and Deactivate methods 
    // and put inside a handler method 
    private void ActivateButton()
    {
        Debug.Log("ActivateButton");
        SetAllButtonsInteractable();
        button.interactable = false;
        InstallationManager.installing = true;
        InstallationManager.selectedPrefab = componentPrefab;
        Debug.Log(InstallationManager.selectedPrefab); 

        if (button.interactable)
        {
            button.interactable = true; 
            InstallationManager.installing = false;
        }
    }
}
