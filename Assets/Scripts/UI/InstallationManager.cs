using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationManager : MonoBehaviour
{
    public HardwareComponent componentBeingInstalled; // priv?

    // Holds a reference to the component being placed's 
    // corresponding prefab  
    public static GameObject prefabBeingInstalled;
    public static bool installing; 

    // redundant?
    public GameObject slopePrefab;
    public GameObject bitPrefab;
    public GameObject terminatorPrefab;

    // this should live elsewhere
    //private void FlipComponent()
    //{

    //}

    private void Update()
    {
        if (Input.GetMouseButtonUp(2))
        {

        }
    }

}
