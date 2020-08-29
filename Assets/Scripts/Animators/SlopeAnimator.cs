using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SlopeAnimator : MonoBehaviour
{
    // better name?
    public GameObject slopeHinge;

    // does this explicit declaration
    // make it more readable?
    Transform slopeTransform; 

    // move this to const class?
    float zDegrees = 90f;

    float startingZ;
    float targetZ;
    float zGap = 40f;

    bool lowering;
    bool raising; 

    // flag for whether its going 
    // left or right?
    // (positive or negative zRot)


    void Start()
    {
        slopeTransform = transform.parent.transform;
        startingZ = transform.rotation.z;
        //targetZ = transform.rotation.z - zGap; 
        targetZ = -60f; 
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

        //while (true)
        //{
        //    if (transform.rotation.z == targetZ)
        //    {

        //    }
        //}


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            //TiltSlope(); 
            lowering = true;
        }
    }

    void ResetRotation(float z)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, z);
    }


    void Update()
    {
        // could ncap. 
        if (lowering)
        {
            if (slopeTransform.rotation.z >= targetZ)
            {
                Debug.Log("Reached target after lowering."); 
                slopeTransform.Rotate(new Vector3(0f, 0f, -ComponentConstants.tiltIncrement)); 
            }
            else 
            {
                ResetRotation(startingZ); 
                lowering = false;
                //raising = true; 
            }
        }
        // range is dependent on direction slope is facing?
        else if (raising)
        {
            if (slopeTransform.rotation.z <= startingZ)
            {
                Debug.Log("Reached target after raising.");
                slopeTransform.Rotate(new Vector3(0f, 0f, ComponentConstants.tiltIncrement));
            }
            else
            {
                ResetRotation(startingZ); 
                raising = false; 
            }
        }
    }
}
