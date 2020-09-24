using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitTrigger : MonoBehaviour
{
    [SerializeField] private Bit bit; 

    void Start()
    {
        //bit = GetComponentInParent<Bit>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            bit.ToggleState(); 
        }
    }
}
