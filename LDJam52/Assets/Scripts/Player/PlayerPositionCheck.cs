using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionCheck : MonoBehaviour
{
    public OxygenTimer oxygenTimer;

    private float xPos;
    private float yPos;

    public float ySurface = -0.5f;

    // Update is called once per frame
    void Update()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;

        UpdateOxygen();
    }

    private void UpdateOxygen()
    {
        if (yPos < ySurface)
        {
            oxygenTimer.regenOxygen = false;
            oxygenTimer.StartTimer();
        }
        else if (yPos > ySurface)
        {
            oxygenTimer.regenOxygen = true;
        }
    }
}
