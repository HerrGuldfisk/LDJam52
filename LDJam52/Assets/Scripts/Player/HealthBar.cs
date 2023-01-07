using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar;

    public float currentHealth;
    public float maxHealth;

    public Text healthText;

    public PlayerData pd;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = pd.maxHealth;
        pd.currentHealth = pd.maxHealth * 0.8f;

        healthBar.value = pd.currentHealth;
    }

    private void Update()
    {
        healthBar.maxValue = pd.maxHealth;
        healthBar.value = pd.currentHealth;
    }

    private void OutOfHealth()
    {
        GameManager.Instance.gameState = GameState.Death;
    }
}
