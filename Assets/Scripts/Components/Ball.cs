using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        Debug.Log("RB velocity:" + rb.velocity);
        Debug.Log("RB magnitude: " + rb.velocity.magnitude); 
        if (rb.velocity.magnitude <= 100f)
        {
            rb.AddTorque(Vector3.one); 
        }
    }
}
