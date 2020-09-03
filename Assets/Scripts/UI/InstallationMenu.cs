using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// separate menu for seeing no. of components?
// /other general UI otptions?
// or just have these on screen (like OnGUI)
// 
public class InstallationMenu : MonoBehaviour
{
    public GameObject slopePrefab;
    public GameObject togglePrefab;

    public Button slopeButton;
    public Button toggleButton;

    public GameObject selectedNode;
    public Vector2 nodePosition; 

    void Start()
    {
        
    }

    void InstallComponent(GameObject _prefab)
    {
        GameObject component = Instantiate(_prefab);
        component.transform.parent = selectedNode.transform; 

        // check if comp. already exists, and destroy if so
        // (see MB logic) 
    }

    void ToggleMenu(GameObject _node)
    {
        // Negate active and set to that(rw) 
        gameObject.SetActive(!gameObject.activeSelf);

        selectedNode = _node;
        SetupListeners(); 
        
    }

    // Adds an onClick listener to each UI button  
    void SetupListeners()
    {
        slopeButton.onClick.RemoveAllListeners();
        slopeButton.onClick.AddListener(delegate { InstallComponent(slopePrefab); });

        toggleButton.onClick.RemoveAllListeners();
        toggleButton.onClick.AddListener(delegate { InstallComponent(togglePrefab); });

    }
}
