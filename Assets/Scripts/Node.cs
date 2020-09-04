using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// rename to peg? 
public class Node : MonoBehaviour, IPointerClickHandler
{
    // prefab array/dict?

    // separate gameObj for builder?
    // distinct from manager? (editor readable)
    public GameObject machineBuilder;
    MachineBuilder builder;

    GameObject attachedComponent; // give node child empty then attach?


    public GameObject installationMenu;
    InstallationMenu menu;

    // parent or child? 
    Button button; 

    public GameObject slopePrefab;
    Vector2 nodePosition; 



    private void Start()
    {
        menu = installationMenu.GetComponent<InstallationMenu>();
        //button = GetComponent<Button>(); 
        nodePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // port to installationmenu script?
    // 
    private void InstallComponent(GameObject _prefab)
    {
        // this method should live in the MB class 
        // Check if component exists on this node  
        if (ComponentIsAttached())
        {
            Destroy(MachineBuilder.componentContainer[nodePosition]); 
            MachineBuilder.componentContainer.Remove(nodePosition);
        }

        Instantiate(slopePrefab);

        // either parent to node or machine top-level
        // hierarchy may be less readable with node parent. z
        slopePrefab.transform.parent = transform;
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

    private void SetupListener()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { menu.ToggleMenu(gameObject); });
    }

    // Check if there is already a component at this node 
    private bool ComponentIsAttached()
    {
        return MachineBuilder.componentContainer.ContainsKey(nodePosition) ? true : false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Left click opens a menu from which 
        // a new component can be selected
        // (line endings?)
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            menu.ToggleMenu(gameObject); 
        }

        // Right click reverses the direction 
        // of the currently attached component
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (ComponentIsAttached())
            {
                // flip ramp z rotation by 180 degrees
                // bit z rotation by 90 degrees 
                // ... 

                // need reference to attached component? 
            }
        }

        // flow pos. 
        throw new System.NotImplementedException();

    }
}
