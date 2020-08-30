using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Redundant? 
public class EndPoint : MonoBehaviour
{
    int delay = 10; 


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            TerminateProgram(); 
        }
    }

    //rename 
    private IEnumerator PreExitDelay()
    {
        int timer = delay; 
        while (delay > 0)
        {
            yield return new WaitForSeconds(1);
            timer--; 
        }
    }

    private void TerminateProgram()
    {
        StartCoroutine(PreExitDelay()); 
        Application.Quit(); 
    }

}
