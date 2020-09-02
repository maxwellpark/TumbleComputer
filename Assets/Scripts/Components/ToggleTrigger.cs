using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// amalgamate with parent script? 
// 
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
            toggle.ToggleState(); 
        }
    }
}
