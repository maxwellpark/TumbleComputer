using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

// rename to program manager?
// then have another module called StateManager 
public class MachineManager : MonoBehaviour
{
    // Change to array of bits later
    //public GameObject zeroBit;
    //public GameObject oneBit; 

    // memory? register? 
    // toggleContainer? 
    public GameObject[] toggles;
    public static int binaryTotal;
    public static int decimalTotal;

    private int fps = 60; 


    // init spawning logic goes here?
    void Start()
    {
        //oneBit.SetActive(false); 

        Application.targetFrameRate = fps;

        AssignToggles(); 
    }

    // ambiguous name because its not a store itself... 
    void AssignToggles()
    {
        int i = 0; 

        // Loop through child objects 
        foreach (Transform _transform in transform)
        {
            if (_transform.tag == "Toggle")
            {
                toggles[i] = _transform.gameObject;
            }
        }
    }

    // update or observer pattern?
    // 
    void Update()
    {
        // does this belong here? 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // const value data abstraction instead of literal?
            ScreenshotManager.TakeScreenshot_Static(500, 500); 
        }

        //Debug.Log("Mousepos " + Input.mousePosition);
    }
}
