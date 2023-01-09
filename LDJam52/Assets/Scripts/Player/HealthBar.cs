using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;

    public float currentHealth;
    public float maxHealth;

    public PlayerData pd;

	public DeathScreen deathScreen;


	// Start is called before the first frame update
	void Start()
    {
        healthBar.maxValue = pd.maxHealth;
        pd.currentHealth = pd.maxHealth * 0.75f;

        healthBar.value = pd.currentHealth;
    }

    private void Update()
    {
        if (pd.currentHealth <= 0)
        {
            OutOfHealth();
        }

        healthBar.maxValue = pd.maxHealth;
        healthBar.value = pd.currentHealth;
    }

    private void OutOfHealth()
    {
		GameManager.Instance.gameState = GameState.Death;
		deathScreen.ShowDeathScreen();
    }
}
