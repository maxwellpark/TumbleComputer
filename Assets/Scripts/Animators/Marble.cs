using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour
{

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 down = transform.TransformDirection(Vector3.down); 

        RaycastHit hit;
        Debug.DrawRay(transform.position, down, Color.yellow);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
}
