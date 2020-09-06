using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationManager : MonoBehaviour
{
    public HardwareComponent componentBeingInstalled; // priv?

    // Holds a reference to the component being placed 
    // (corresponding prefab) 
    public static GameObject currentlyInstallingPrefab;

    public GameObject slopePrefab;
    public GameObject bitPrefab;
    public GameObject terminatorPrefab;
    

}
