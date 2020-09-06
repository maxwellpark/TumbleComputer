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
    // The prefab of the component installed by this button
    [SerializeField] private GameObject componentPrefab; 

    // The buttons that comprise the installation menu 
    [SerializeField] private Button[] buttons;

    // The button component attached to the GameObject that 
    // this script is attached to 
    Button button;

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

    private void ActivateButton()
    {
        Debug.Log("ActivateButton");
        SetAllButtonsInteractable();
        button.interactable = false;
        InstallationManager.prefabBeingInstalled = componentPrefab;
        Debug.Log(InstallationManager.prefabBeingInstalled); 
    }

    // explain this method 
    //public void OnButtonClicked(Button clickedButton)
    //{
    //    Debug.Log("OnBtnClicked"); 
    //    int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

    //    if (buttonIndex == -1)
    //        return;

    //    SetAllButtonsInteractable();

    //    clickedButton.interactable = false;

    //    // Set the prefab that will be instantiated at a chosen node 
    //    InstallationManager.prefabBeingInstalled = componentPrefab; 


    //}
}
