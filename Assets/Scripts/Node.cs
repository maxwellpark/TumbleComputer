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
    public static event Action<GameObject> onInstallation; // decoupling this would be preferable...

    public GameObject board; 
    // prefab array/dict?

    // separate gameObj for builder?
    // distinct from manager? (editor readable)
    public GameObject machineBuilder;
    MachineBuilder builder;

    GameObject attachedComponent; // give node child empty then attach?

    // This is set to true if the node can
    // only install gear components
    private bool restrictedInstallation; 

    [SerializeField] private bool occupied; 
    //[SerializeField] private float yOffset;


    //public GameObject installationMenu;
    //InstallationMenu menu;

    // parent or child? 

    public GameObject slopePrefab;

    Vector2 nodePosition;
    Vector2 newComponentPosition;
    float yDelta = 0.75f; // but will vary depending on comp. type 


    private void Start()
    {
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
            if (restrictedInstallation && InstallationManager.selectedPrefab.name == "GearPrefab") 
            {
                return; 
            }

            attachedComponent = Instantiate(InstallationManager.selectedPrefab, board.transform);
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
            MachineBuilder.componentGrid.Add(attachedComponent.transform.position, attachedComponent);
            //
            // we could do away with the KVP and just have a List<Transform> or List<Vector2> 
            // and lookup based on those
            // then we could get the gameObject through transform.gameObject*
        }
    }

    //private [] GetCorrespondingScript()
    //{
           // switch stmt. 
           // return Bit if bit component, GearBit if gearbit, etc.
    //}

    private void UninstallComponent()
    {
        onInstallation?.Invoke(MachineBuilder.componentGrid[nodePosition]);
        Destroy(MachineBuilder.componentGrid[nodePosition]);
        MachineBuilder.componentGrid.Remove(nodePosition);
    }

    private GameObject GetCorrespondingPrefab(HardwareComponent component)
    {
        switch (component) 
        {
            case HardwareComponent.Slope:
                return slopePrefab;


            default:
                // return empty gameObj representing null? 
                return slopePrefab; 
        }
    }

    //private void AddListener()
    //{
    //    Button button = GetComponent<Button>();
    //    button.onClick.RemoveAllListeners();
    //    button.onClick.AddListener(delegate 
    //    { 
    //        InstallComponent(InstallationManager.selectedPrefab); 
    //    });
    //}

    // Check if there is already a component at this node 
    private bool ComponentIsAttached()
    {
        return MachineBuilder.componentGrid.ContainsKey(nodePosition);
    }

    private void FlipComponent()
    {
        Debug.Log("Flipping component");
        attachedComponent.transform.eulerAngles += new Vector3(0f, 0f, 180f);

        //attachedComponent.transform.eulerAngles = new Vector3
        //    (
        //    attachedComponent.transform.eulerAngles.y, 
        //    attachedComponent.transform.eulerAngles.x, 
        //    attachedComponent.transform.eulerAngles.z + 180f
        //    );

        //attachedComponent.transform.Rotate()
        Debug.Log("New eulerAngles: " + attachedComponent.transform.eulerAngles); 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Left click opens a menu from which 
        // a new component can be selected
        // (line endings?)
        if (eventData.button == PointerEventData.InputButton.Left && 
            InstallationManager.installing)
        {
            //menu.ToggleMenu(gameObject); 
            InstallComponent();

        }

        // Right click reverses the direction 
        // of the currently attached component
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (occupied)
            {
                // flip ramp z rotation by 180 degrees
                // bit z rotation by 90 degrees 
                // ... 

                // need reference to attached component? 
                FlipComponent(); 
            }
        }

        //throw new System.NotImplementedException();
    }
}
