using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// rename to peg? 
public class Node : MonoBehaviour, IPointerClickHandler
{
    public GameObject board; 
    // prefab array/dict?

    // separate gameObj for builder?
    // distinct from manager? (editor readable)
    public GameObject machineBuilder;
    MachineBuilder builder;

    GameObject attachedComponent; // give node child empty then attach?


    //public GameObject installationMenu;
    //InstallationMenu menu;

    // parent or child? 

    public GameObject slopePrefab;
    Vector2 nodePosition; 



    private void Start()
    {
        //menu = installationMenu.GetComponent<InstallationMenu>();
        //button = GetComponent<Button>(); 
        //AddListener();
        nodePosition = new Vector2(transform.position.x, transform.position.y);

    }

    // port to installationmenu script?
    // 
    private void InstallComponent(GameObject _prefab)
    {
        Debug.Log("InstallComponent"); 
        // this method should live in the MB class 
        // Check if component exists on this node  
        if (ComponentIsAttached())
        {
            Destroy(MachineBuilder.componentContainer[nodePosition]); 
            MachineBuilder.componentContainer.Remove(nodePosition);
        }

        GameObject newComponent = Instantiate(InstallationManager.currentlyInstallingPrefab);

        // either parent to node or machine top-level
        // hierarchy may be less readable with node parent. 
        newComponent.transform.parent = board.transform;
        newComponent.transform.position = nodePosition; 
        //newComponent.transform.localPosition = Vector2.one;
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
    //        InstallComponent(InstallationManager.currentlyInstallingPrefab); 
    //    });
    //}

    // Check if there is already a component at this node 
    private bool ComponentIsAttached()
    {
        return MachineBuilder.componentContainer.ContainsKey(nodePosition);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        // Left click opens a menu from which 
        // a new component can be selected
        // (line endings?)
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("InstallComponent");
            //menu.ToggleMenu(gameObject); 
            InstallComponent(InstallationManager.currentlyInstallingPrefab);

        }

        // Right click reverses the direction 
        // of the currently attached component
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (ComponentIsAttached())
            {
                Debug.Log("Component already attached to node");
                // flip ramp z rotation by 180 degrees
                // bit z rotation by 90 degrees 
                // ... 

                // need reference to attached component? 
            }
        }

        //throw new System.NotImplementedException();
    }
}
