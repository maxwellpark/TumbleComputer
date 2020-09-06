using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// amalgamate with parent script? 
// 
// just get a reference to the trigger gameobject* 
public class ToggleTrigger : MonoBehaviour
{
    Toggle toggle; 

    void Start()
    {
        toggle = GetComponentInParent<Toggle>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            StartCoroutine(ToggleDelay()); 
            toggle.ToggleState(); 
        }
    }

    IEnumerator ToggleDelay()
    {
        yield return new WaitForSeconds(1); 
    }
}
