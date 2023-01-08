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

	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnUpDown(InputValue value)
	{
		if(value.Get<float>() == 0)
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
	}

	void OnOpen()
	{
		switch (selectedObject)
		{
			case 0:
				UpgradeOxygen();
				break;

		}
	}

	void UpgradeOxygen()
	{
		if(pd.currentOxygenLevel < 2)
		{
			if (pd.currentMoney >= 50 + (100 * pd.currentOxygenLevel))
			{
				pd.currentMoney -= 50 + (100 * pd.currentOxygenLevel);
				pd.oxygenMax = pd.oxygenUpgrades[pd.currentOxygenLevel];
				pd.currentOxygenLevel += 1;
				shopTexts.upgradeOxygen = $"Upgrade Oxygen {50 + (100 * pd.currentOxygenLevel)}";
				moneyField.text = pd.currentMoney.ToString() + "g";
			}
		}


	}
}
