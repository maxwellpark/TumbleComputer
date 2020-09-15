using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBit : MonoBehaviour
{
    // how to do away with trigger object referencing?

    private Vector2[] neighbourPositions;
    private GameObject[] neighbours; // populate through MB 

    bool state; 

    void Start()
    {
        // just get relative positions from MachineBuilder dict instead?
        neighbourPositions = new Vector2[]
        {
            new Vector2(transform.position.x - 3f, transform.position.y), 
            new Vector2(transform.position.x + 3f, transform.position.y),
            new Vector2(transform.position.y - 3f, transform.position.x),
            new Vector2(transform.position.y + 3f, transform.position.x),
        };
        
        // FindObjectByCoordinates() helper fn
    }


    private void OnCollisionEnter(Collision collision)
    {

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
            if (MachineBuilder.componentData.ContainsKey(neighbour))
            {
                //opposite rotation 
                //MachineBuilder.componentData[neighbour].gameObject.transform.rotation.eulerAngles = 
            }
        }
    }
    void Update()
    {
        
    }
}
