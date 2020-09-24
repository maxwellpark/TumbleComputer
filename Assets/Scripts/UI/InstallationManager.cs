using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallationManager : MonoBehaviour
{
    // Holds a reference to the component being placed's corresponding prefab  
    public static GameObject selectedPrefab;

    public static bool installing; 

    public static float GetYDelta()
    {
        switch (selectedPrefab.transform.tag)
        {
            case "Ramp":
                return MachineConstants.rampYDelta;
            case "Bit":
                return MachineConstants.bitYDelta;
            case "GearBit":
                return MachineConstants.gearBitYDelta;
            case "Gear":
                return MachineConstants.gearYDelta;
            case "Crossover":
                return MachineConstants.crossoverYDelta;
            case "Interceptor":
                return MachineConstants.interceptorYDelta;
            default:
                return 0f; 
        }
    }
}
