using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureBar : MonoBehaviour
{
	public Slider pressureUI;

	public PlayerData pd;

    // Update is called once per frame
    void Update()
    {
		pressureUI.maxValue = pd.pressureMax;
		pressureUI.value = pd.currentPressure;

		if(pd.currentPressure > pd.pressureMax)
		{
			TakePressureDamage();
		}
    }

	void TakePressureDamage()
	{
		pd.currentHealth -= Time.deltaTime * (5f + (pd.currentPressureLevel + 1));
	}
}
