using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConstants : MonoBehaviour
{
    // Coordinates at which balls will be released 
    public static Vector3 blueReleasePoint = new Vector3(0.5f, 2.5f, 1f);
    public static Vector3 redReleasePoint = new Vector3(17.5f, 2.5f, 1f); 

    // Spacing between nodes 
    public static float xSpacing = 3f; 
    public static float ySpacing = 3f;

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
