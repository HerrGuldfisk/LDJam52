using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerPositionCheck : MonoBehaviour
{
    public OxygenTimer oxygenTimer;
    public MovementCardinal movementCardinal;

	public PlayerData pd;

    private float xPos;
    private float yPos;

    private float ySurface = 0.0f;
    private float yAirzone = -1f;

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
			if(GameManager.Instance.gameState == GameState.Airbourne)
			{
				movementCardinal.rb.velocity *= 0.5f;
				GameManager.Instance.gameState = GameState.Default;
			}

            pd.currentPressure = yPos * -1;
        }
    }
}
