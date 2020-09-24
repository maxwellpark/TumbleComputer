using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBit : MonoBehaviour
{
    public GameObject attachedNode;

    private List<GameObject> neighbours = new List<GameObject>();
    private Vector2[] neighbourPositions;

    private bool state;

    void Start()
    {
        neighbourPositions = new Vector2[]
        {
            new Vector2(transform.position.x - 3f, transform.position.y),
            new Vector2(transform.position.x + 3f, transform.position.y),
            new Vector2(transform.position.y - 3f, transform.position.x),
            new Vector2(transform.position.y + 3f, transform.position.x),
        };

        UpdateNeighbours(); 
    }

    private void Flip()
    {
        state = !state;
        //transform.eulerAngles += state ? new Vector3(0f, 0f, -zDelta) : new Vector3(0f, 0f, zDelta);

    }

    private void RotateNeighbours()
    {
        foreach (GameObject neighbour in neighbours)
        {
            //neighbour.transform.eulerAngles += state ? new Vector3(0f, 0f, zDelta) : new Vector3(0f, 0f, -zDelta); // opposite 

        }
    }

    private void UpdateNeighbours()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Flip(); 
        RotateNeighbours();    
    }
}
