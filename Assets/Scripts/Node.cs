using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// prevent installing/altering components while machine is running? 

// rename to peg? 
// separation of concerns is not good here
public class Node : MonoBehaviour, IPointerClickHandler
{
    public GameObject machineBuilder;
    private GameObject grid; 

    private GameObject attachedComponent;

    // This is set to true if the node can
    // only install gear components
    [SerializeField] private bool restrictedInstallation; 

    /*[SerializeField] */private bool occupied; 

    Vector2 nodePosition;
    Vector2 newComponentPosition;
    float yDelta = 0.75f; // but will vary depending on comp. type 

    public static event Action<GameObject> onInstallation; // decoupling this would be preferable...

    private void Start()
    {
        // 
        grid = transform.parent.transform.parent.gameObject; 
        //menu = installationMenu.GetComponent<InstallationMenu>();
        //button = GetComponent<Button>(); 
        //AddListener();
        nodePosition = new Vector2(transform.position.x, transform.position.y);
        newComponentPosition = new Vector2(transform.position.x, transform.position.y + yDelta);
         
    }

    // port to installationmenu script? (SoC) 
    // 
    private void InstallComponent()
    {
        if (InstallationManager.selectedPrefab != null)
        {
            Debug.Log("InstallComponent"); 
            // this method should live in the MB class 
            // Check if component exists on this node  
            if (ComponentIsAttached())
            {
                Destroy(MachineBuilder.componentGrid[nodePosition]); 
                MachineBuilder.componentGrid.Remove(nodePosition);
                // we need to destroy the attached component 
                // can we get reference without using MachineBuilder?
                // & 
            }

            // Only gears are permitted if the node is restricted 
            // explain how some nodes are restricted later 
            if (restrictedInstallation && InstallationManager.selectedPrefab.transform.tag == "GearBit" /*InstallationManager.selectedPrefab.name == "GearPrefab"*/) 
            {
                return; 
            }

            attachedComponent = Instantiate(InstallationManager.selectedPrefab, grid.transform);
            attachedComponent.name = InstallationManager.selectedPrefab.ToString();
            Debug.Log("Newly installed component game object name: " + attachedComponent.name); 

            // either parent to node or machine top-level
            // hierarchy may be less readable with node parent. 

            // do we need the instantiated object's position or the attached node position?
            // to add to the componentGrid?
            attachedComponent.transform.position = newComponentPosition; 

            //newComponent.transform.localPosition = Vector2.one;

        
            occupied = true;

            // invoke here 
            onInstallation?.Invoke(MachineBuilder.componentGrid[nodePosition]);

            // or just .Add to the componentGrid 
            MachineBuilder.componentGrid.Add(/*attachedComponent.transform.position*/ nodePosition, attachedComponent);
            //
            // we could do away with the KVP and just have a List<Transform> or List<Vector2> 
            // and lookup based on those
            // then we could get the gameObject through transform.gameObject*
        }
    }

    private void UninstallComponent()
    {
        onInstallation?.Invoke(MachineBuilder.componentGrid[nodePosition]);
        Destroy(MachineBuilder.componentGrid[nodePosition]);
        MachineBuilder.componentGrid.Remove(nodePosition);
    }

    // Check if there's already a component at this node 
    private bool ComponentIsAttached()
    {
        return MachineBuilder.componentGrid.ContainsKey(nodePosition);
    }

    private void FlipComponent()
    {
        float zRotation = GetZRotation(attachedComponent);
        attachedComponent.transform.eulerAngles += new Vector3(0f, 0f, zRotation);
        Debug.Log("New eulerAngles: " + attachedComponent.transform.eulerAngles); 
    }

    private float GetZRotation(GameObject component)
    {
        switch (component.transform.tag)
        {
            case "Ramp":
                return 20f;
            case "Bit":
                return 90f;
            case "GearBit":
                return 90f;
            default:
                return 0f; 
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && InstallationManager.installing)
        {
            InstallComponent();
        }

        // Right click reverses the direction 
        // of the currently attached component
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("RMB"); 
            if (occupied)
            {
                Debug.Log("IsOccupied"); 
                FlipComponent(); 
            }
        }
    }
}
