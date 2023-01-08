using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
	public TextMeshProUGUI dialogueText;

	public PlayerData pd;

	public Animator anim;

	public PersistentData persistentData;

	float time;

	// public List<string> cptPepTalk = new List<string>();

	public void ShowDeathScreen()
	{
		time = Time.unscaledTime;
		GameManager.Instance.gameState = GameState.Dialogue;

		anim.Play("Run");

		// While too deep
		if(pd.currentPressure > pd.pressureMax)
		{
			SetText("Oy lad... even the greenest sailors know that you don't go below your max depth. I guess i should tell the next cadet how pressure upgrades work...");
			return;
		}

		if(pd.currentHealth <= 0)
		{
			SetText("No one ever told you to be gentle width things you borrow shark bait?");
			return;
		}

		// Death while at depth
		if(pd.currentPressure < 5f)
		{
			SetText("Dying at the depth of a puddle, what a way to go...");
			return;
		}
		else if(pd.currentPressure < 50f)
		{
			SetText("The paper work o the paper work, argh bloody paper cut");
			return;
		}
		else if (pd.currentPressure < 100f)
		{
			SetText("A proper send of of old Betty, almost sad that I need to find a new shark bait, I started to like this one");
			return;
		}
		else if (pd.currentPressure < 150f)
		{
			SetText("Down with the ship, a proper captain. I raise my jar for you shark bait. You almost made it");
			return;
		}
		else if (pd.currentPressure < 200f)
		{
			SetText("You should have reached the bottom, were my map incorrect? Did you run off with my treasure shark bait?");
			return;
		}

	}

	private void SetText(string text)
	{
		dialogueText.text = text;
	}

	void OnRespawn()
	{
		if(GameManager.Instance.gameState == GameState.Dialogue)
		{
			Debug.Log("Respawn button");

			Time.timeScale = 1;
			anim.Play("Reset");
			GameManager.Instance.gameState = GameState.Default;
			SceneManager.LoadSceneAsync(0);
		}
	}
}
