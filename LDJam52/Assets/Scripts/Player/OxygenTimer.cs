using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTimer : MonoBehaviour
{
    public Slider OxygenBar;

    public float timeRemaining;
    public float maxTime;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public bool timerIsRunning = false;

    public Text timeText;

    public PlayerData pd;

    public static OxygenTimer instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxTime = pd.oxygenMax;

        timeRemaining = maxTime;

        OxygenBar.maxValue = maxTime;
        OxygenBar.value = maxTime;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                OutOfOxygen();
            }

            OxygenBar.value = timeRemaining;
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

    public void ResetTimer()
    {
        PauseTimer();
        maxTime = pd.oxygenMax;
        OxygenBar.maxValue = maxTime;
        timeRemaining = maxTime;
        StartTimer();
    }

    public void StartRegenOxygen()
    {
        PauseTimer();
        if (regen != null)
            StopCoroutine(regen);

        regen = StartCoroutine(RegenOxygen());
    }

    private IEnumerator RegenOxygen()
    {
        yield return new WaitForSeconds(0.5f);

        while (timeRemaining < maxTime)
        {
            timeRemaining += maxTime / 60;
            OxygenBar.value = timeRemaining;
            yield return regenTick;
        }
        regen = null;
    }

    public void OutOfOxygen()
    {
        Debug.Log("Time has run out!");

        timeRemaining = 0;
        PauseTimer();
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
