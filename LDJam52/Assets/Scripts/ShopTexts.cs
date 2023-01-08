using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTexts : MonoBehaviour
{
	public PlayerData pd;

	public List<string> oxygenUpgrades = new List<string>();
	public List<string> hullUpgrades = new List<string>();
	public List<string> pressureUpgrades = new List<string>();

	public string upgradeOxygen = $"Upgrade oxygen 50g";
	public string upgradeHull = "Upgarde hull 50g";
	public string upgradePressure = "Upgrade pressure 50g";
}
