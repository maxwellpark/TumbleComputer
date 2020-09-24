using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    // make the spawnpoint dynamic 
    private Vector3 spawnPoint = new Vector3(1.5f, 3f, 0f);

    [SerializeField] private GameObject architecture;
    [SerializeField] private GameObject entryPoint; // exit pt. doesn't work 
    [SerializeField] private GameObject marblePrefab;

    private int deadMarbles; 

    // Start is called before the first frame update
    void Start()
    {
        architecture = gameObject.transform.parent.gameObject; 
    }   

    private void RespawnMarble()
    {
        Debug.Log("Respawn fired"); 
        GameObject newMarble = Instantiate(marblePrefab);
        newMarble.transform.parent = architecture.transform;
        //newMarble.transform.position = spawnPoint; 

        // place it above the ep 
        newMarble.transform.position = entryPoint.transform.position + new Vector3(0f, 4f, 0f); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Marble")
        {
            Destroy(collision.gameObject);
            deadMarbles++; 
            Debug.Log($"Marble {deadMarbles} reached the sink.");
            RespawnMarble(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
