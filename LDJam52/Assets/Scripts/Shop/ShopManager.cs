using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
	public int selectedObject = 0;

	bool allowInput = true;

	public List<GameObject> backgrounds = new List<GameObject>();

	public ShopTexts shopTexts;
	public PlayerData pd;
	public TextMeshProUGUI moneyField;

	public TextMeshProUGUI header;
	public TextMeshProUGUI explanation;

	public OxygenTimer oxygenTimer;


	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnEnable()
	{
		SetSelectedOption();
	}

	void OnUpDown(InputValue value)
	{
		if(value.Get<float>() >= -0.2f && value.Get<float>() <= 0.2f)
		{
			allowInput = true;
			return;
		}

		if (!allowInput) { return; }

		allowInput = false;

		float direction = value.Get<float>();

		if(direction > 0)
		{
			selectedObject -= 1;
			selectedObject = Mathf.Clamp(selectedObject, 0, 2);

		}
		else if(direction < 0)
		{
			selectedObject += 1;
			selectedObject = Mathf.Clamp(selectedObject, 0, 2);
		}

		SetSelectedOption();
	}

	void SetSelectedOption()
	{
		foreach(GameObject bg in backgrounds)
		{
			bg.SetActive(false);
		}

		backgrounds[selectedObject].SetActive(true);

		switch (selectedObject)
		{
			case 0:
				header.text = shopTexts.upgradeOxygen + $" {50 + (100 * (pd.currentOxygenLevel * pd.currentOxygenLevel))}" + "g";
				explanation.text = shopTexts.oxygenUpgrades[pd.currentOxygenLevel];
				break;
			case 1:
				header.text = shopTexts.upgradeHull + $" {50 + (100 * (pd.currentHullLevel * pd.currentHullLevel))}" + "g";
				explanation.text = shopTexts.hullUpgrades[pd.currentHullLevel];
				break;
			case 2:
				header.text = shopTexts.upgradePressure + $" {50 + (100 * (pd.currentPressureLevel * pd.currentPressureLevel))}" + "g";
				explanation.text = shopTexts.pressureUpgrades[pd.currentPressureLevel];
				break;
		}

	}

	void OnOpen()
	{
		switch (selectedObject)
		{
			case 0:
				UpgradeOxygen();
				break;
			case 1:
				UpgradeHull();
				break;
			case 2:
				UpgradePressure();
				break;
		}
	}

	void UpgradeOxygen()
	{
		if(pd.currentOxygenLevel < 2)
		{
			if (pd.currentMoney >= 50 + (100 * (pd.currentOxygenLevel * pd.currentOxygenLevel)))
			{
				oxygenTimer.UpdateOxygenMaxLimit(pd.oxygenUpgrades[pd.currentOxygenLevel]);

				pd.currentMoney -= 50 + (100 * (pd.currentOxygenLevel * pd.currentOxygenLevel));
				pd.oxygenMax = pd.oxygenUpgrades[pd.currentOxygenLevel];
				pd.currentOxygenLevel += 1;
				shopTexts.upgradeOxygen = $"Upgrade Oxygen Tank";
				moneyField.text = pd.currentMoney.ToString() + "g";
				SetSelectedOption();
			}
		}
	}

	void UpgradeHull()
	{
		if (pd.currentHullLevel < 2)
		{
			if (pd.currentMoney >= 50 + (100 * (pd.currentHullLevel * pd.currentHullLevel)))
			{
				pd.currentMoney -= 50 + (100 * (pd.currentHullLevel * pd.currentHullLevel));
				pd.maxHealth = pd.hullUpgrades[pd.currentHullLevel];
				pd.currentHealth = pd.maxHealth;
				pd.currentHullLevel += 1;
				shopTexts.upgradeHull = $"Upgrade Hull Strength";
				moneyField.text = pd.currentMoney.ToString() + "g";
				SetSelectedOption();
			}
		}
	}

	void UpgradePressure()
	{
		if (pd.currentPressureLevel < 2)
		{
			if (pd.currentMoney >= 50 + (100 * (pd.currentPressureLevel * pd.currentPressureLevel)))
			{
				pd.currentMoney -= 50 + (100 * (pd.currentPressureLevel * pd.currentPressureLevel));
				pd.pressureMax = pd.pressureUpgrades[pd.currentPressureLevel];
				pd.currentPressureLevel += 1;
				shopTexts.upgradePressure = $"Upgrade Pressure";
				moneyField.text = pd.currentMoney.ToString() + "g";
				SetSelectedOption();
			}
		}
	}
}
