using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBit : MonoBehaviour
{
    // how to do away with trigger object referencing?

    public GameObject attachedNode; 

    private Vector2[] neighbourPositions;
    //private GameObject[] neighbours; // populate through MB 
    //private Dictionary<Orientation, GameObject> neighbours; 

    // neighbours array is fine because we don't need to know 
    // where they are in relation to the object instance?
    private List<GameObject> neighbours = new List<GameObject>();

    bool state;
    float zDelta = 90f; 

    // do we need an event that fires when only Gears are installed, 
    // so that the neighbours array can be updated with new references?

    void Start()
    {
        //neighbours = new Dictionary<Orientation, GameObject>();
        
        // subscribe to the oninstallation event here 
        // so whenever gear components are added or destroyed,
        // we can update the neighbours array 

        //AddNeighbours(); 

        // just get relative positions from MachineBuilder dict instead?
        neighbourPositions = new Vector2[]
        {
            // can these be moved to a static class? (they are they same 
            // as all (just pass in the transform.position of the object 
            // instance in question) 
            new Vector2(transform.position.x - 3f, transform.position.y), 
            new Vector2(transform.position.x + 3f, transform.position.y),
            new Vector2(transform.position.y - 3f, transform.position.x),
            new Vector2(transform.position.y + 3f, transform.position.x),
        };

        // should it be utils, not constants?
        // since it can change at any moment...
        neighbours = MachineConstants.GetNeighbourPositions(neighbourPositions);

        // can we just use the componentGrid instead of this local List? 

        //foreach (Vector2 _position in neighbourPositions)
        //{
        //    if(MachineBuilder.componentGrid.ContainsKey(_position))
        //    {
        //        neighbours.Add(MachineBuilder.componentGrid[_position]); 
        //    }
        //}
        

        // FindObjectByCoordinates() helper fn
        // does this conflict with other subscriptions?

        // invoke here 
        //Node.onInstallation += UpdateNeighbours(); 
    }


    // subscribe to an event in the GearTrigger class?
    //private void OnCollisionEnter(Collision collision)
    //{
    //    foreach (GameObject _neighbour in neighbours)
    //    {
    //        // could be easier to use built-in local rotation method 
    //        float _neighbourZRotation = _neighbour.transform.rotation.eulerAngles.z;
    //        _neighbour.transform.rotation.eulerAngles.Set(0f, 0f, _neighbourZRotation + 90f);
    //    }

    //    // this is a suboptimal way of rotating neighbours 
    //    //for (int i = 0; i < 4; i++)
    //    //{
    //    //    // update neighbour transform.rotation on collision 
    //    //}
    //    //transform.rotation.eulerAngles = 


    //    //foreach (GameObject neighbour in neighbours)
    //    //{
    //    //    //opposite rotation 
    //    //    //neighbour.transform.rotation.eulerAngles =
    //    //}
    //}

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
        //foreach (Vector2 neighbour in neighbourPositions)
        //{
        //    // how to check if component is of type gear?
        //    if (MachineBuilder.componentGrid.ContainsKey(neighbour))
        //    {


        //        //opposite rotation 
        //        //MachineBuilder.componentGrid[neighbour].gameObject.transform.rotation.eulerAngles = 
        //    }
        //}

        foreach (GameObject neighbour in neighbours)
        {
            // need to do +/-, (or conditional rotation based on current state)
            //neighbour.transform.rotation =
            neighbour.transform.eulerAngles += state ? new Vector3(0f, 0f, zDelta) : new Vector3(0f, 0f, -zDelta); // opposite 
            
        }
    }

    // this is unnecessarily unDRY 
    void AddNeighbours()
    {
        //neighbours.Add(Orientation.West, MachineBuilder.componentGrid[new Vector2(
        //    transform.position.x - MachineConstants.xSpacing, transform.position.y)]);
        //neighbours.Add(Orientation.East, MachineBuilder.componentGrid[new Vector2(
        //    transform.position.x + MachineConstants.xSpacing, transform.position.y)]);
        //neighbours.Add(Orientation.South, MachineBuilder.componentGrid[new Vector2(
        //    transform.position.y - MachineConstants.ySpacing, transform.position.y)]);
        //neighbours.Add(Orientation.North, MachineBuilder.componentGrid[new Vector2(
        //    transform.position.y + MachineConstants.ySpacing, transform.position.y)]);
    }

    private void UpdateNeighbours(GameObject neighbour)
    {
        // switch vector2 and get direction from xy values?
        // or pass in an Orientation param?
    }

    void Update()
    {
        
    }

    // can we have 2 box colliders firing this method?
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Flip(); 
        RotateNeighbours();    
    }
}
