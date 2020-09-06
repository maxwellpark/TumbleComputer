using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputReport : MonoBehaviour
{
    // tell the user the result of their calculation
    // /the pattern their program made 
    // /other details about the execution 
    // any errors? 

    MachineManager manager; 

    Rect outputLabel;
    int width = 64, height = 64, x = 16, y = 32; 


    void Start()
    {
        manager = GetComponent<MachineManager>(); 
        outputLabel = new Rect(width, height, x, y);
    }

    void Update()
    {
        
    }

    //private void OnGUI()
    //{
    //    GUI.Label(outputLabel, $"Total: {MachineManager.decimalTotal}"); 
    //    // binary rep.
    //    // estimation of execution time remaining? 

    //    if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
    //    {
    //        print("You clicked the button!");
    //    }
    //}
}
