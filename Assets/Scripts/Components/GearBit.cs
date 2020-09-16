using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBit : MonoBehaviour
{
    // how to do away with trigger object referencing?

    public GameObject attachedNode; 

    private Vector2[] neighbourPositions;
    //private GameObject[] neighbours; // populate through MB 
    private Dictionary<Orientation, GameObject> neighbours; 

    bool state;
    float zDelta = 90f; 

    void Start()
    {
        neighbours = new Dictionary<Orientation, GameObject>();

        // subscribe to the oninstallation event here 
        // so whenever gear components are added or destroyed,
        // we can update the neighbours array 

        AddNeighbours(); 

        // just get relative positions from MachineBuilder dict instead?
        neighbourPositions = new Vector2[]
        {
            new Vector2(transform.position.x - 3f, transform.position.y), 
            new Vector2(transform.position.x + 3f, transform.position.y),
            new Vector2(transform.position.y - 3f, transform.position.x),
            new Vector2(transform.position.y + 3f, transform.position.x),
        };

        // FindObjectByCoordinates() helper fn
        // does this conflict with other subscriptions
        Node.onInstallation += UpdateNeighbours(); 
    }


    // subscribe to an event in the GearTrigger class?
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < 4; i++)
        {
            
        }
        //transform.rotation.eulerAngles = 


        //foreach (GameObject neighbour in neighbours)
        //{
        //    //opposite rotation 
        //    //neighbour.transform.rotation.eulerAngles =
        //}
    }

    private void Flip()
    {
        state = !state;
        //transform.rotation.eulerAngles = 

        // can we make this try by creating a static method 
        // that handles rotation for all components?
        transform.eulerAngles += state ? new Vector3(0f, 0f, -zDelta) : new Vector3(0f, 0f, zDelta);


    }

    private void RotateNeighbours()
    {
        // get NESW neighbours in MB dict. 
        // by using neighbouringNodes values as keys
        // 
        // 
        foreach (Vector2 neighbour in neighbourPositions)
        {
            // how to check if component is of type gear?
            if (MachineBuilder.componentGrid.ContainsKey(neighbour))
            {
                //opposite rotation 
                //MachineBuilder.componentGrid[neighbour].gameObject.transform.rotation.eulerAngles = 
            }
        }
    }

    void AddNeighbours()
    {
        neighbours.Add(Orientation.West, MachineBuilder.componentGrid[new Vector2(
            transform.position.x - MachineConstants.xSpacing, transform.position.y)]);
        neighbours.Add(Orientation.East, MachineBuilder.componentGrid[new Vector2(
            transform.position.x + MachineConstants.xSpacing, transform.position.y)]);
        neighbours.Add(Orientation.South, MachineBuilder.componentGrid[new Vector2(
            transform.position.y - MachineConstants.ySpacing, transform.position.y)]);
        neighbours.Add(Orientation.North, MachineBuilder.componentGrid[new Vector2(
            transform.position.y + MachineConstants.ySpacing, transform.position.y)]);
    }

    private void UpdateNeighbours(GameObject neighbour)
    {
        // switch vector2 and get direction from xy values?
        // or pass in an Orientation param?
    }

    void Update()
    {
        
    }
}
