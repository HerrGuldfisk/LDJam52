using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionCheck : MonoBehaviour
{
    public OxygenTimer oxygenTimer;
    public MovementCardinal movementCardinal;

    private float xPos;
    private float yPos;

    public float ySurface = 0.0f;
    public float yAirzone;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;

        UpdateOxygen();
        UpdateMovement();
    }

    private void UpdateOxygen()
    {
        if (yPos < yAirzone)
        {
            oxygenTimer.regenOxygen = false;
            oxygenTimer.StartTimer();
        }
        else if (yPos > yAirzone)
        {
            oxygenTimer.regenOxygen = true;
        }
    }

    private void UpdateMovement()
    {
        if (yPos > ySurface)
        {
            GameManager.Instance.gameState = GameState.Airbourne;
        }
        else
        {
            GameManager.Instance.gameState = GameState.Default;
        }
    }
}
