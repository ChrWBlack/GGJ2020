using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RobotBehaviour Robot;
    public Tutorial TutorialManager;
    private float gameTime = 0.0f;
    private bool gameRunning = false;

    public CanvasGroup GameStateUI;
    public CanvasGroup TimerUI;
    public Text GameState;
    public Text TimeDisplay;

    public GameObject meteorVehicle1;
    public GameObject meteorVehicle2;

    private bool meteorsInitiated = false;

    // Start is called before the first frame update
    void Start()
    {
        Robot.OnDeath += OnRobotDeath;
        TutorialManager.TutorialFinished += OnGameStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime > 19 && !meteorsInitiated)
        {
            InitiateMeteors();
        }

        if (gameRunning)
        {
            gameTime += Time.deltaTime;
            // TODO: UPDATE GAME TIME ON GUI
            float milliSecs = gameTime * 1000;
            int mins = Mathf.FloorToInt(milliSecs / 60000.0f);
            int sec = Mathf.FloorToInt((milliSecs - 60000.0f * mins) / 1000.0f);
            int mSec = Mathf.FloorToInt(milliSecs % 1000);
            TimeDisplay.text = mins + ":" + ((sec < 10) ? ("0") : ("")) + sec + ":" + ((mSec < 10) ? ("00") : (mSec < 100) ? ("0") : ("")) + mSec;
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
        StartCoroutine(FadeInGameStateUI());
        TimerUI.GetComponent<Animator>().SetTrigger("Highlight");
    }

    private void OnGameStart()
    {
        gameRunning = true;
    }

    IEnumerator FadeInGameStateUI()
    {
        while (GameStateUI.alpha < 1)
        {
            GameStateUI.alpha += Time.deltaTime * 2;
            GameStateUI.alpha = Mathf.Clamp01(GameStateUI.alpha);
            yield return new WaitForEndOfFrame();
        }
    }

    private void InitiateMeteors()
    {
        meteorVehicle1.GetComponent<MeteorVehicleBehavior>().TimeForMeteor();
        meteorVehicle2.GetComponent<MeteorVehicleBehavior>().TimeForMeteor();
        meteorsInitiated = true;
    }
}
