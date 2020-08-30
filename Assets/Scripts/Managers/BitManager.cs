using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BitManager : MonoBehaviour
{
    // Change to array of bits later 
    // (if using MachineManager overarching) 
    ////public GameObject zeroBit;
    ////public GameObject oneBit;

    // Change to alt? (from their script, they 
    // are not encoded like this...) 


    // Naive solution?
    public int cooldownPeriod;

    public void FlipBit(GameObject zeroBit, GameObject oneBit)
    {
        // Flip first bit 
        zeroBit.SetActive(!zeroBit.activeSelf);
        Bit zeroBitScript = zeroBit.GetComponent<Bit>();
        zeroBitScript.state = !zeroBitScript.state;

        // Flip second bit 
        oneBit.SetActive(!oneBit.activeSelf);
        Bit oneBitScript = oneBit.GetComponent<Bit>();
        oneBitScript.state = !oneBitScript.state;

        StartCoroutine(cooldownFlip());
    }

    public IEnumerator cooldownFlip()
    {
        int timer = cooldownPeriod;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
    }


    //public IEnumerator cooldownFlip()
    //{
    //    int timer = cooldownPeriod;
    //    while (timer > 0)
    //    {
    //        yield return new WaitForSeconds(1);
    //        timer--; 
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Marble")
    //    {
    //        Debug.Log("Bit collision fired");
    //        FlipBit(zeroBit, oneBit);  
    //    }
    //}

    void Update()
    {

    }
}
