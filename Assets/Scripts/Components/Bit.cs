using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change this so there's one component for ramping, 
// but an enum controls whether it changes the ball's
// direction or not (and so on) 
public class Bit : MonoBehaviour
{
    // Need to attach this script to a separate 
    // (parent?) gameObject, then adjust the collider 
    // based on its state 

    // Ramp objects that represent binary numbers,
    // and also change the direction of the ball 
    //public GameObject zeroRamp;
    //public GameObject oneRamp;

    public GameObject ramp;
    public GameObject altRamp;
    public BitManager bitManager;

    public bool state; 

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            Debug.Log("Bit collision fired");
            //bitManager.FlipBit(ramp, altRamp);  
            bitManager.FlipBit(ramp, altRamp); 
        }
    }

    void FlipBit()
    {
        state = !state;
        ramp.SetActive(!ramp.activeSelf);
        altRamp.SetActive(!altRamp.activeSelf); 
    }

    void Update()
    {
        
    }
}
