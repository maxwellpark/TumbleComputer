using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

// Change to static Animation class for all components? 
public class RampAnimation : MonoBehaviour
{
    // set AMs later in accordance with best practices (writeup padding) 
    
    public GameObject ball; 
    public GameObject ramp;

    int rotationDegrees = 90;
    float rotationIncrement = 1f; 
    int rotationTime = 64;
    int timeDelay; 


    // increments of rot. = degrees/time 

    private IEnumerator GradualRotation(Transform _transform)
    {
        int countdown = rotationDegrees; 
        while (countdown > 0)
        {
            //_transform.rotation += new Quaternion()
            //_transform.localRotation.eulerAngles += 
            countdown--;
            yield return new WaitForSeconds(timeDelay); 
        }

    }

    private void Start()
    {
        //StartCoroutine(GradualRotation(ramp.transform));
    }

    // Use raycasting instead 
    //private void OnCollisionEnter(Collision collision)
    //{
    //    StartCoroutine(GradualRotation(ramp.transform));
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, 90f)); 

        }
        //StartCoroutine(GradualRotation(gameObject.transform)); 
    }

    private void FixedUpdate()
    {

    }

    
}
