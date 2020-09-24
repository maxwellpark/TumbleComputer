using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConstants : MonoBehaviour
{
    // Coordinates at which balls will be released 
    public static Vector3 blueReleasePoint = new Vector3(0.5f, 3.5f, 0f);
    public static Vector3 redReleasePoint = new Vector3(20f, 3.5f, 0f);

    // Distance on y axis between nodes are their attached components,
    // which varies component to component 
    public static float rampYDelta = 0.75f;
    public static float bitYDelta = 0.25f;
    public static float gearBitYDelta = 0.75f;
    public static float gearYDelta = 0.75f;
    public static float crossoverYDelta = 0.75f;
    public static float interceptorYDelta = 0.75f;

    // Spacing between nodes 
    public static float xSpacing = 3f; 
    public static float ySpacing = 3f;

    // Button colours 
    public static Color buttonSelectedColour = new Color(1f, 1f, 1f, 50f);
    public static Color buttonDeselectedColour = new Color(1f, 1f, 1f, 255f); 

    // does this really belong here?
    public static List<GameObject> GetNeighbourPositions(Vector2[] _positions)
    {
        List<GameObject> _neighbours = new List<GameObject>();

        foreach (Vector2 _position in _positions)
        {
            if (MachineBuilder.componentGrid.ContainsKey(_position))
            {
                _neighbours.Add(MachineBuilder.componentGrid[_position]);
            }
        }

        return _neighbours;
    }
}
