using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 force;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = new Vector3(12f, 0f, 0f);
        rb.AddForce(force);
    }
}
