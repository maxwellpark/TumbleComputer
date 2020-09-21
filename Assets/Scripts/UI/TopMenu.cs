using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum TopButtonType
{
    BlueBall, RedBall, BallReset, MachineReset, MachineStart 
}

public class TopMenu : MonoBehaviour
{
    public MachineBuilder machineBuilder; 

    public GameObject grid; // naming convention 
    public GameObject ballContainer; 
    public GameObject blueBallPrefab; 
    public GameObject redBallPrefab;

    public Button blueBallButton;
    public Button redBallButton;
    public Button ballResetButton;
    public Button componentResetButton;
    public Button machineStartButton;

    void Start()
    {
        SetupListener(blueBallButton, ReleaseBlueBall);
        SetupListener(redBallButton, ReleaseRedBall);
        SetupListener(ballResetButton, ResetBalls);
        SetupListener(componentResetButton, ResetComponents);
    }

    void SetupListener(Button button, UnityAction handler)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(handler);
    }

    void ReleaseBlueBall()
    {
        GameObject ball = Instantiate(blueBallPrefab, ballContainer.transform);
        ball.transform.position = MachineConstants.blueReleasePoint; 
    }

    void ReleaseRedBall()
    {
        GameObject ball = Instantiate(redBallPrefab, ballContainer.transform);
        ball.transform.position = MachineConstants.redReleasePoint;
    }

    void ResetBalls()
    {
        // use container instead? 
        //GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        //foreach (GameObject ball in balls)
        //{
        //    Destroy(ball.transform); 
        //}
        foreach (Transform _transform in ballContainer.transform)
        {
            Destroy(_transform.gameObject); 
        }
    }

    void ResetComponents()
    {
        machineBuilder.DestroyAllComponents(); 
        //MachineBuilder.DestroyAllComponents();
    }
}
