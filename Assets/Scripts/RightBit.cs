using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBit : MonoBehaviour
{
    public GameObject leftBit;
    
    // we dont need this ref 
    public GameObject rightBit;
    private bool state = false;



    // Start is called before the first frame update
    void Start()
    {
        // change to gameObject.setActive
        rightBit.SetActive(state); 
    }
    void FlipBit()
    {
        state = true;
        leftBit.SetActive(true);
        rightBit.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            FlipBit(); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
