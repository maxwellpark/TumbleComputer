using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBuilder : MonoBehaviour
{
    // top row always needs to be 6? 
    // row below is always 3 + top row? (9)
    [SerializeField] int numberOfNodes;
    
    // stores type and position of components 
    public static GameObject[] componentObjects;

    // use this to iterate through building process later 
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

    // Start is called before the first frame update
    void Start()
    {
        
        // pos of top rung bits based on entrypos and entrywidth/height 
        // prefab with bit rotated 45 degrees either way 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
