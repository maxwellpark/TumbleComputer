using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossover : MonoBehaviour
{
    // z position of LFrame and RFrame needs to be 
    // less than that of the crossover base (behind it) 

    // think of a more original name for this component 

    // what logic is required for crossover 
    // if rigidbody is used 

    // use this to keep track of other ball positions
    // when they change paths (directions), update state 
    // 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // this needs to be linked to the child collider, 
    // not the empty parent object 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            // update location of marble (node ref.) 
            // based on crossover location +/- direction (L/R)

            //collision.nodeReference = currentNode -
            //collision.currentLevel--; 

        }
    }
}
