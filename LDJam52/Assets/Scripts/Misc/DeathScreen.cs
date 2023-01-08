using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
	public GameObject deathCanvas;
	public TextMeshProUGUI dialogueText;

	public PlayerData pd;

	public List<string> cptPepTalk = new List<string>();

	public void EnableDeathScreen()
	{
		deathCanvas.SetActive(true);

		if(pd.currentHealth <= 0)
		{

		}

	}

	private void SetText(int index)
	{
		dialogueText.text = cptPepTalk[1];
	}
}
