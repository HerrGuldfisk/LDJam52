using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMoneyUI : MonoBehaviour
{
	int lastMoney = -1;

	public PlayerData pd;
	public TextMeshProUGUI moneyField;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lastMoney != pd.currentMoney)
		{
			moneyField.text = $"{pd.currentMoney}g";
			lastMoney = pd.currentMoney;
		}
    }
}
