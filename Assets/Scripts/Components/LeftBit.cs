using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Left bit shouldn't be dominant (responsibility)
// BitManager makes more sense 
public class LeftBit : MonoBehaviour
{
    // redundant 
    public GameObject leftBit;
    
    public GameObject rightBit;
    [SerializeField] private bool state = false; 

    // Array of these left-right bit pairs? 
    // Or individual attachments. 


    // Start is called before the first frame update
    void Start()
    {
        leftBit.SetActive(state);
        rightBit.SetActive(!state); 
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
