using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Observe the bit components 
// Update decimalValue accordingly 
public class Operand : MonoBehaviour
{
    private int decimalValue; 

    // need to make bit universal 
    // not left-right 
    // so we can count bools 
    private GameObject[] bits;

    // constants file port 
    private int labelX = 10;
    private int labelY = 10;
    private int labelWidth = 100;
    private int labelHeight = 20; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnGUI()
    {
        // need to position it based on opposing operand's label 
        GUI.Label(new Rect(labelX, labelY, labelWidth, labelHeight), $"{decimalValue}"); 
    }
}
