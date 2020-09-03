using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// rename to peg? 
public class Node : MonoBehaviour
{
    // prefab array/dict?

    public GameObject slopePrefab;
    Vector2 nodePosition; 

    private void Start()
    {
        nodePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // port to installationmenu script?
    // 
    private void InstallComponent(GameObject _prefab)
    {
        // this method should live in the MB class 
        // Check if component exists on this node  
        if (MachineBuilder.componentContainer.ContainsKey(nodePosition))
        {
            Destroy(MachineBuilder.componentContainer[nodePosition]); 
            MachineBuilder.componentContainer.Remove(nodePosition);
        }

        Instantiate(slopePrefab);

        // either parent to node or machine top-level
        // hierarchy may be less readable with node parent. z
        slopePrefab.transform.parent = transform;
    }

    private GameObject GetCorrespondingPrefab(HardwareComponent component)
    {
        switch (component) 
        {
            case HardwareComponent.Slope:
                return slopePrefab;


            default:
                // return empty gameObj representing null? 
                return slopePrefab; 
        }
    }
}
