using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationManager : MonoBehaviour
{
    // Observer 
    public static event Action onInstallation; 

    public HardwareComponent componentBeingInstalled; // priv?

    // Holds a reference to the component being placed's 
    // corresponding prefab  
    public static GameObject selectedPrefab;

    public static bool installing; 

    // redundant?
    public GameObject slopePrefab;
    public GameObject bitPrefab;
    public GameObject terminatorPrefab;

    //public static event Action onInstallation;

    // This is the prefab currently being installed. 
    // It corresponds to an installation button
    //private GameObject selectedPrefab; 

    // this should live elsewhere
    //private void FlipComponent()
    //{

    //}

    private GameObject GetSelectedPrefab()
    {
        return selectedPrefab;
    }

    private void SetSelectedPrefab(GameObject prefab)
    {
        selectedPrefab = prefab; 
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(2))
        {
            // hotkey for removing components 
            // logic should go here 
        }
    }

}
