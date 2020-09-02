using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // init spawning logic goes here?
    void Start()
    {
        //oneBit.SetActive(false); 

        Application.targetFrameRate = 60;

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
        
    }
}
