using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// prevent installing/altering components while machine is running? 

// rename to peg? 
// separation of concerns is not good here
public class Node : MonoBehaviour, IPointerClickHandler
{
    public GameObject board; 
    // prefab array/dict?

    // separate gameObj for builder?
    // distinct from manager? (editor readable)
    public GameObject machineBuilder;
    MachineBuilder builder;

    GameObject attachedComponent; // give node child empty then attach?

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

    // port to installationmenu script?
    // 
    private void InstallComponent()
    {
        if (InstallationManager.prefabBeingInstalled != null)
        {
            Debug.Log("InstallComponent"); 
            // this method should live in the MB class 
            // Check if component exists on this node  
            if (ComponentIsAttached())
            {
                Destroy(MachineBuilder.componentData[nodePosition]); 
                MachineBuilder.componentData.Remove(nodePosition);
                // we need to destroy the attached component 
                // can we get reference without using MachineBuilder?
                // & 
            }

            //GameObject newComponent = Instantiate(InstallationManager.prefabBeingInstalled);
            attachedComponent = Instantiate(InstallationManager.prefabBeingInstalled);

            // either parent to node or machine top-level
            // hierarchy may be less readable with node parent. 
            attachedComponent.transform.parent = board.transform;
            attachedComponent.transform.position = newComponentPosition; 
            //newComponent.transform.localPosition = Vector2.one;
        
            occupied = true; 
        }
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
    //        InstallComponent(InstallationManager.prefabBeingInstalled); 
    //    });
    //}

    // Check if there is already a component at this node 
    private bool ComponentIsAttached()
    {
        return MachineBuilder.componentData.ContainsKey(nodePosition);
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
