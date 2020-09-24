using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    private bool flipped; 

    public void Flip()
    {
        flipped = !flipped;
        transform.localEulerAngles = flipped ?
            new Vector3(transform.position.x, transform.position.y, MachineConstants.rampZRotationFlipped) :
            new Vector3(transform.position.x, transform.position.y, MachineConstants.rampZRotation); 
    }

    public void PointRight()
    {
        transform.localEulerAngles = MachineConstants.rampRotation;
    }

    public void PointLeft()
    {
        transform.localEulerAngles = MachineConstants.rampRotationFlipped; 
    }
}
