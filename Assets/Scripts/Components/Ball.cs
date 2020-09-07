using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    Vector3 force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = new Vector3(12f, 0f, 0f);
        rb.AddForce(force);
        //rb.AddForce(force, ForceMode.Acceleration);
    }

    private void FixedUpdate()
    {
        Debug.Log("RB velocity:" + rb.velocity);
        Debug.Log("RB magnitude: " + rb.velocity.magnitude); 
        if (rb.velocity.magnitude <= 100f)
        {
            //rb.AddTorque(Vector3.one); 
        }
    }
}
