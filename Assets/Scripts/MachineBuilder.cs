using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBuilder : MonoBehaviour
{
    public GameObject togglePrefab; 
    
    // top row always needs to be 6? 
    // row below is always 3 + top row? (9)
    [SerializeField] int numberOfNodes;
    
    // stores type and position of components 
    public static GameObject[] componentObjects;

    // rn 
    // is dict necessary? - holds the coords and the obj  
    
    // <Coords, Prefab> 
    public static Dictionary<Vector2, GameObject> componentContainer = new Dictionary<Vector2, GameObject>();

    //public static Dictionary<Vector2, HardwareComponent> componentContainer;

    // use this to iterate through building process later 
    // might be redundant if prefabs are used in lieu 
    public static HardwareComponent[] hardwareComponents;  


    // 
    // 
    // or calculate based on dimensions of other components
    int width;
    int height;

    // break out into constants class 
    int rampwidth;
    int rampheight;
    int rampspacing; //? redundant?
    int rampangle; // flipped left/right parts 

    Vector2 entrypos;
    Vector2 sinkpos;

    // coords should be such that they are 
    // right in the centre of the corresponding node 
    Vector2 testKey = new Vector2(16f, 16f);
    GameObject testValue;  

    void Start()
    {
        componentContainer = new Dictionary<Vector2, GameObject>();
        testValue = togglePrefab;

        //testValue = Instantiate(togglePrefab);
        //testValue.transform.parent = transform.parent.transform;

        // pos of top rung bits based on entrypos and entrywidth/height 
        // prefab with bit rotated 45 degrees either way 

        componentContainer.Add(testKey, testValue); 


    }

    void BuildMachine()
    {
        foreach (KeyValuePair<Vector2, GameObject> entry in componentContainer)
        {
            // comment this 
            GameObject component = Instantiate(entry.Value);
            component.transform.parent = transform.parent.transform;
            component.transform.position = entry.Key; 
            
        }
    }

    void Update()
    {
        
    }
}
