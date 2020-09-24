using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTrigger : MonoBehaviour
{
    private Toggle toggle; 

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
