using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MachineBuilder : MonoBehaviour
{
    // Can access any component in the grid via its coordinates
    public static Dictionary<Vector2, GameObject> componentGrid = new Dictionary<Vector2, GameObject>();

    public GameObject componentContainer;

    void Start()
    {
        DestroyGameObjects(componentContainer.transform);
    }

    public void DestroyGameObjects(Transform container)
    {
        foreach (Transform _transform in container)
        {
            Destroy(_transform.gameObject);
        }
    }

    public static string LogComponentGrid()
    {
        string log = string.Empty;
        int counter = 0;

        foreach (KeyValuePair<Vector2, GameObject> entry in componentGrid)
        {
            log += $"ComponentGrid entry #{counter}: {entry} \n";
            counter++;
        }

        return log;
    }
}