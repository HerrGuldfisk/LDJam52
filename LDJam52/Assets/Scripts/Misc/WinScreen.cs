using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
	public Animator anim;

	public PersistentData persistentData;

	public void ShowDeathScreen()
	{
		GameManager.Instance.gameState = GameState.Dialogue;

		anim.Play("ShowWin");
	}

	void OnRespawn()
	{
		if (GameManager.Instance.gameState == GameState.Dialogue)
		{
			Debug.Log("Respawn button");

			Time.timeScale = 1;
			GameManager.Instance.gameState = GameState.Default;
			SceneManager.LoadSceneAsync(0);
		}
	}
}
