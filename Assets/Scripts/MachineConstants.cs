using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConstants : MonoBehaviour
{
    // Coordinates at which balls will be released 
    public static Vector3 blueReleasePoint = new Vector3(0.5f, 3.5f, 0f);
    public static Vector3 redReleasePoint = new Vector3(17.5f, 3.5f, 0f);

    // Distance on y axis between nodes are their attached components,
    // which varies component to component 
    public static float rampYDelta = 0.5f;
    public static float bitYDelta = 0.25f;
    public static float gearBitYDelta = 0.75f;
    public static float gearYDelta = 0.75f;
    public static float crossoverYDelta = 0.75f;
    public static float interceptorYDelta = 0.75f;

    // Z axis rotation values
    public static float rampZRotation = -20f;
    public static float rampZRotationFlipped = 20f; 
    public static float bitZRotation = 90f;

    // Eulers 
    public static Vector3 rampRotation = new Vector3(0f, 0f, -20f);
    public static Vector3 rampRotationFlipped = new Vector3(0f, 0f, 20f);

    // Button colours 
    public static Color buttonSelectedColour = new Color(1f, 1f, 1f, 50f);
    public static Color buttonDeselectedColour = new Color(1f, 1f, 1f, 255f);
}