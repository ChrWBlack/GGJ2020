using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RobotBehaviour Robot;
    private float gameTime = 0.0f;
    private bool gameRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        Robot.OnDeath += OnRobotDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            gameTime += Time.deltaTime;
            // TODO: UPDATE GAME TIME ON GUI
        }

        if (Input.GetAxis("Restart") > 0.5f)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    private void OnRobotDeath()
    {
        gameRunning = false;
        // TODO: SHOW GAME OVER GUI
    }

    private void OnGameStart()
    {
        gameRunning = true;
    }
}
