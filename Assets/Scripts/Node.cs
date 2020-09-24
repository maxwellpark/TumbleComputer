using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour, IPointerClickHandler
{
    public MachineBuilder machineBuilder;

    public GameObject componentContainer;
    private GameObject attachedComponent;

    // This is set to true if the node can only install gear components
    [SerializeField] private bool restrictedInstallation;

    private bool occupied;

    private Vector2 nodePosition;

    private void Start()
    {
        nodePosition = new Vector2(transform.position.x, transform.position.y);
    }

    private void InstallComponent()
    {
        if (InstallationManager.selectedPrefab != null)
        {
            if (ComponentIsAttached())
            {
                Destroy(MachineBuilder.componentGrid[nodePosition]);
                MachineBuilder.componentGrid.Remove(nodePosition);
            }

            // Only gears are permitted if the node is restricted 
            if (restrictedInstallation && InstallationManager.selectedPrefab.transform.tag != "GearBit")
            {
                return;
            }

            attachedComponent = Instantiate(InstallationManager.selectedPrefab, componentContainer.transform);
            attachedComponent.name = InstallationManager.selectedPrefab.ToString();

            // Y position is component type-specific 
            attachedComponent.transform.position = new Vector3(
                transform.position.x, transform.position.y + InstallationManager.GetYDelta(), 0f);

            MachineBuilder.componentGrid.Add(nodePosition, attachedComponent);
            Debug.Log(MachineBuilder.LogComponentGrid());
            
            occupied = true;
        }
    }

    private void UninstallComponent()
    {
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
        //float zRotation = GetZRotation(attachedComponent);
        //attachedComponent.transform.eulerAngles += new Vector3(0f, 0f, zRotation);
        //Debug.Log("Flipping with RMB underway");
        //Debug.Log("New eulerAngles: " + attachedComponent.transform.eulerAngles);
        switch (attachedComponent.transform.tag)
        {
            case "Ramp":
                Ramp ramp = attachedComponent.GetComponent<Ramp>();
                ramp.Flip();
                //if (ramp.transform.eulerAngles.z == 20f)
                //{
                //    ramp.PointRight();
                //}
                //else if (ramp.transform.eulerAngles.z == -20f)
                //{
                //    ramp.PointLeft();
                //}

                break;

            case "Bit":
                Bit bit = attachedComponent.GetComponent<Bit>();
                bit.ToggleState();
                break; 
            
                
        }
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

        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (occupied)
            {
                FlipComponent();
            }
        }
    }
}