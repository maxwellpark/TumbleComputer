using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// rename to peg? 
public class Node : MonoBehaviour
{
    // prefab array/dict?

    // separate gameObj for builder?
    // distinct from manager? (editor readable)
    public GameObject machineBuilder;
    MachineBuilder builder;

    public GameObject installationMenu;
    InstallationMenu menu;

    // parent or child? 
    Button button; 

    public GameObject slopePrefab;
    Vector2 nodePosition; 



    private void Start()
    {
        menu = installationMenu.GetComponent<InstallationMenu>();
        button = GetComponent<Button>(); 
        nodePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // port to installationmenu script?
    // 
    private void InstallComponent(GameObject _prefab)
    {
        // this method should live in the MB class 
        // Check if component exists on this node  
        if (MachineBuilder.componentContainer.ContainsKey(nodePosition))
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
}
