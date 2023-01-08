using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
	public int currentMoney = 200;

	public float cardinalSpeedMAX = 5f;
	public float cardinalAccelleration = 1.5f;

	public float oxygenMax = 30f;

	public float pressureMax = 100f;
	public float currentPressure = 0f;

	public float maxHealth = 100f;
	public float currentHealth;

	public int inventorySpace = 3;

	public List<float> oxygenUpgrades = new List<float>();
	public List<float> hullUpgrades = new List<float>();
	public List<float> pressureUpgrades = new List<float>();

	public int currentOxygenLevel = 0;
	public int currentHullLevel = 0;
	public int currentPressureLevel = 0;

	public int GAMEMAXDEPTH = 180;

	public void UpgradeOxygen()
	{
		//if()
	}
}
