using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Ramp : MonoBehaviour
{
    // Need reference to gameObject and 
    // the alternate ramp 

    public GameObject ball;
    public GameObject ramp;
    public GameObject altRamp; 

    // Change visual effect to light bulb?
    // Switch on when bit is 1 
    public Material whiteMaterial;
    public Material blackMaterial; 
    public Renderer _renderer; 

    // 0 is false, 1 is true 
    private bool state; 

    private void Start()
    {
        //ball = GameObject.Find("Marble"); 
        _renderer.material.color = Color.black; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            ChangeState(); 
        }
    }

    private void ChangeState()
    {
        // Toggle value of state 
        state = !state;
        //renderer.material = state ? whiteMaterial : blackMaterial; 
        _renderer.material.color = state ? Color.white : Color.black;
    }

    private void Update()
    {
        
    }
}
