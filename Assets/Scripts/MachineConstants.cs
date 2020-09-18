using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineConstants : MonoBehaviour
{
    public static float xSpacing = 3f; 
    public static float ySpacing = 3f;

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
