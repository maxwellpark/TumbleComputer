using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// port this
// rename too? 
public enum HardwareComponent
{
    Blank = 0, Slope = 1, Toggle = 2, Crossover /*rename*/ = 3, Endpoint = 4
    // no need for sink (default position)
    // same with some others 
}

public class ExternalProgramParser : MonoBehaviour
{
    //private string rawTextData; 
    private string pathToFile;
    public string[] externalProgram; 

    void Start()
    {
        // file can omit the square brackets 
        // (already in 2d arr format) 
        externalProgram = File.ReadAllLines(pathToFile); 
        
        // problem is: need to strip the gaps between component chars 
        // otherwise the indices don't match up 
        // *explain this in writeup
        // list the problems to solve

    }

    void Parse()
    {
        // for loop more suitable? 
        //
        int index = 0; 

        // string elements represent nodes in arr 
        foreach (string node in externalProgram)
        {
            // ncap. 
            switch(node)
            {
                // bring in utils & machine builder methods 
                case "B":
                    // how to know node no.s in builder?
                    // index the str arr and one-to-one map with GameObject arr? 
                    // ^ 

                    //MachineBuilder.componentObjects[index] = node;

                    MachineBuilder.hardwareComponents[index] = HardwareComponent.Blank; 
                    // nodeComponent = HardwareComponent.Blank 
                   break;

                case "S":
                    MachineBuilder.hardwareComponents[index] = HardwareComponent.Slope;
                    break;

                case "T":
                    MachineBuilder.hardwareComponents[index] = HardwareComponent.Toggle;
                    break;

                case "C":
                    MachineBuilder.hardwareComponents[index] = HardwareComponent.Crossover;
                    break;

                case "E":
                    MachineBuilder.hardwareComponents[index] = HardwareComponent.Endpoint;
                    break;

                // better to have single assignment to the static arr here?
                // 
                //MachineBuilder.hardwareComponents[index] = nodeComponent;
            }
            index++; 
        }
    }

    void MapStringToComponent()
    {

    }

    void Update()
    {
        
    }
}
