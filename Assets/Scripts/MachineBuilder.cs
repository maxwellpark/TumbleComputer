using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MachineBuilder : MonoBehaviour
{
    public GameObject componentContainer; // the one in the editor 
    public GameObject nodePrefab; 
    public GameObject togglePrefab; 
    
    // top row always needs to be 6? 
    // row below is always 3 + top row? (9)
    //
    // is no. of nodes just the active ones?
    // (that can have components attached) 
    [SerializeField] int numberOfNodes;
    int defaultNumberOfNodes = 100;

    int levels = 6;
    int nodesPerLevel = 12;
    float xSpacing = 3f;
    float ySpacing = 3f; 
    
    // stores type and position of components 
    //public static GameObject[] componentObjects;

    // rn 
    // is dict necessary? - holds the coords and the obj  
    
    // <Coords, Prefab> 
    public static Dictionary<Vector2, GameObject> componentData = new Dictionary<Vector2, GameObject>();

    //public static Dictionary<Vector2, HardwareComponent> componentData;

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
        DestroyAllComponents(); 

        if (numberOfNodes <= 0)
        {
            numberOfNodes = defaultNumberOfNodes;
        }

        componentData = new Dictionary<Vector2, GameObject>();
        testValue = togglePrefab;

        //testValue = Instantiate(togglePrefab);
        //testValue.transform.parent = transform.parent.transform;

        // pos of top rung bits based on entrypos and entrywidth/height 
        // prefab with bit rotated 45 degrees either way 

        // later we'll add an iterative method for generating data
        componentData.Add(testKey, testValue);

        BuildMachine(); 
    }

    void BuildMachine()
    {
        foreach (KeyValuePair<Vector2, GameObject> entry in componentData)
        {
            // comment this 
            GameObject component = Instantiate(entry.Value);
            component.transform.parent = componentContainer.transform;
            component.transform.position = entry.Key; 
            
        }
    }
    
    // separate methods for first and second row?
    // (those that have different pattern) 
    void SetupNodes()
    {
        for (int i = 0; i < levels; i++)
        {
            float xPos = 3f;
            float yPos = 0f; 

            // first two levels are different 
            // if (i != 0 && i != 1) 
            if (1 == 1)
            {
                for (int j = 0; j < nodesPerLevel; j++)
                {
                    GameObject node = Instantiate(nodePrefab);
                    node.transform.parent = transform; // might have a node container later...

                    // does this affect local pos?
                    node.transform.position = new Vector2(xPos, yPos);

                    // These become the next node's coordinates  
                    xPos += xSpacing;
                    yPos += ySpacing;
                }

            }
            else
            {
                // less nodes than the rest. 
                // spacing is different (make separate variable or just manipulate here) 
                // (remember to restore sparing var. afterwards) 
            }
        }
    }

    void DestroyAllComponents()
    {
        foreach (Transform _transform in componentContainer.transform)
        {
            Destroy(_transform.gameObject);
        }
    }

    void Update()
    {
        
    }
}
