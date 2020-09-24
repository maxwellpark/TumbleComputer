using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    private enum BallColour
    {
        Blue = 0, Red = 1
    }

    [SerializeField] private BallColour ballColour;

    [SerializeField] private GameObject ballContainer;
    [SerializeField] private GameObject ballPrefab;

    private void RespawnMarble()
    {
        GameObject newMarble = Instantiate(ballPrefab, ballContainer.transform);
        newMarble.transform.localPosition = ballColour == BallColour.Blue ?
            MachineConstants.blueReleasePoint : MachineConstants.redReleasePoint;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Marble")
        {
            RespawnMarble();
        }
    }
}