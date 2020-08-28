using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SlopeAnimator : MonoBehaviour
{
    // better name?
    public GameObject slopeHinge;

    // move this to const class?
    float zDegrees = 90f; 

    // flag for whether its going 
    // left or right?
    // (positive or negative zRot)


    void Start()
    {
        
    }

    void TiltSlope()
    {
        // flag needs to affect this... (not - sign)...
        StartCoroutine(GradualTilt(-zDegrees));

        // Return the slope to its original rotation
        StartCoroutine(GradualTilt(zDegrees)); 
    }

    // 
    IEnumerator GradualTilt(float zDegrees)
    {
        // is int viable here? 
        // explain dtype choices in writeup*
        //float timer = ComponentConstants.tiltDuration;
        float timer = 9f; 

        // make this a const. 
        // and dynamicv
        //float delay = timer / 100f; 
        float delay = 0.01f; 

        while (timer > 0)
        {
            // Rotate by increment defined in CC class 
            slopeHinge.transform.Rotate(new Vector3(0f, 0f, ComponentConstants.tiltIncrement));
            yield return new WaitForSeconds(delay);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            TiltSlope(); 
        }
    }


    void Update()
    {
        
    }
}
