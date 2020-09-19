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
    public GameObject grid; // naming convention 
    public GameObject blueBallPrefab; 
    public GameObject redBallPrefab;

    public Button blueBallButton;
    public Button redBallButton;
    public Button ballResetButton;
    public Button componentResetButton;
    public Button machineStartButton;

    private Vector2 blueReleasePoint;
    private Vector2 redReleasePoint; 

    void Start()
    {
        SetupListener(blueBallButton, ReleaseBlueBall);
        SetupListener(redBallButton, ReleaseRedBall);
        SetupListener(ballResetButton, ResetBalls);
        SetupListener(componentResetButton, ResetComponents);
    }

    void SetupListener(Button button, UnityAction handler)
    {
        //button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(handler);
    }

    // port these methods to MachineBuilder?
    // (for separation of concerns) 
    void ReleaseBlueBall()
    {
        GameObject ball = Instantiate(blueBallPrefab, grid.transform);
        ball.transform.position = blueReleasePoint; 
    }

    void ReleaseRedBall()
    {
        GameObject ball = Instantiate(redBallPrefab, grid.transform);
        ball.transform.position = redReleasePoint;
    }

    void ResetBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball.transform); 
        }
    }

    void ResetComponents()
    {
        //MachineBuilder.DestroyAllComponents(); 
    }


}
