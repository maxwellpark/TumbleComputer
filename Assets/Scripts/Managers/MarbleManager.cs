using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleManager : MonoBehaviour
{
    // change AMs pre-release 
    public Vector3 blueSpawnPoint, redSpawnPoint;

    private void Start()
    {
        blueSpawnPoint = new Vector3(0.48f, 2.92f, 0f);
        redSpawnPoint = new Vector3(17.52f, 2.92f, 0f); 
    }


}
