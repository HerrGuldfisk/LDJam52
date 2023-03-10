using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTimer : MonoBehaviour
{
    public Slider oxygenBar;

    public float timeRemaining;
    public float maxTime;

    public bool regenOxygen;

    public bool timerIsRunning = false;

    public PlayerData pd;

    public static OxygenTimer instance;

	public DeathScreen deathScreen;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxTime = pd.oxygenMax;

        timeRemaining = maxTime;

        oxygenBar.maxValue = maxTime;
        oxygenBar.value = maxTime;
    }

    void Update()
    {
        if (!regenOxygen)
        {
            if (timerIsRunning && GameManager.Instance.gameState != GameState.Dialogue)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    OutOfOxygen();
                }

                oxygenBar.value = timeRemaining;
            }
        }
        else
        {
            if (timeRemaining < maxTime)
            {
                timeRemaining += maxTime / 2 * Time.deltaTime;
                oxygenBar.value = timeRemaining;
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void PauseTimer()
    {
        timerIsRunning = false;
    }

    public void UpdateOxygenMaxLimit(float value)
    {
        maxTime = value;
        oxygenBar.maxValue = maxTime;
    }

    public void ResetTimer()
    {
        PauseTimer();
        UpdateOxygenMaxLimit(maxTime);
        timeRemaining = maxTime;
        StartTimer();
    }

    public void OutOfOxygen()
    {
        Debug.Log("Time has run out!");

        timeRemaining = 0;
        PauseTimer();

        GameManager.Instance.gameState = GameState.Death;

		deathScreen.ShowDeathScreen();
    }
}
