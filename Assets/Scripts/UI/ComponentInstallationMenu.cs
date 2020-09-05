using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentInstallationMenu : MonoBehaviour
{
    public GameObject container;

    // can we just loop through the enum itself? 
    private HardwareComponent[] components = new HardwareComponent[]
    {
        HardwareComponent.Slope, HardwareComponent.Toggle
    };

    private void Start()
    {
        
    }

    // listener sets the InstallationManager enum 
    // (currently active installer) 
}
