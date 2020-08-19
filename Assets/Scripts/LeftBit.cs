using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBit : MonoBehaviour
{
    public GameObject leftBit;
    public GameObject rightBit;
    [SerializeField] private bool state = true; 

    // Array of these left-right bit pairs? 
    // Or individual attachments. 


    // Start is called before the first frame update
    void Start()
    {
        leftBit.SetActive(state); 
    }
    void FlipBit()
    {
        state = false; 
        leftBit.SetActive(false);
        rightBit.SetActive(true); 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            FlipBit();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
