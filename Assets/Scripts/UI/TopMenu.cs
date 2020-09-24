using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
    public MachineBuilder machineBuilder; 

    public GameObject grid; 
    public GameObject ballContainer;  
    public GameObject componentContainer; 
    public GameObject blueBallPrefab; 
    public GameObject redBallPrefab;

    public Button blueBallButton;
    public Button redBallButton;
    public Button ballResetButton;
    public Button componentResetButton;

    private void Start()
    {
        SetupListener(blueBallButton, ReleaseBlueBall);
        SetupListener(redBallButton, ReleaseRedBall);
        SetupListener(ballResetButton, ResetBalls);
        SetupListener(componentResetButton, ResetComponents);
    }

    private void SetupListener(Button button, UnityAction handler)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(handler);
    }

    private void ReleaseBlueBall()
    {
        GameObject ball = Instantiate(blueBallPrefab, ballContainer.transform);
        ball.transform.localPosition = MachineConstants.blueReleasePoint;
        Debug.Log("Blueballpos; " + ball.transform.position); 
    }

    private void ReleaseRedBall()
    {
        GameObject ball = Instantiate(redBallPrefab, ballContainer.transform);
        ball.transform.position = MachineConstants.redReleasePoint;
    }

    private void ResetBalls()
    {
        machineBuilder.DestroyGameObjects(ballContainer.transform); 
    }

    private void ResetComponents()
    {
        machineBuilder.DestroyGameObjects(componentContainer.transform); 
    }
}
