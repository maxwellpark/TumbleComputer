using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// static rotation might be clearer...
public class BitAnimator : MonoBehaviour
{
    // The bit that this GameObject triggers 
    public Toggle toggle; 

    private float zDelta = 90f;
    private float rotationRate;
    private Vector3 eulers;
    private bool flippingRight;
    private bool flippingLeft;

    private void Start()
    {
        rotationRate = zDelta / 10f;
        eulers = new Vector3(0f, 0f, rotationRate);
    }

    // calculate euler angles to add per frame;
    // turn off flag when OnCollisionExit is called
    private void OnCollisionEnter(Collision collision)
    {
        if (toggle.state)
        {
            flippingLeft = true;
        }
        else
        {
            flippingRight = true; 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (flippingLeft)
        {
            flippingLeft = false; 
        }
        else if (flippingRight)
        {
            flippingRight = false; 
        }
    }

    private void Update()
    {
        if (flippingLeft)
        {
            toggle.transform.eulerAngles += eulers; 
        }
        else if (flippingRight)
        {
            toggle.transform.eulerAngles -= eulers; 
        }
    }



}
