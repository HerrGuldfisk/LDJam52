using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public PlayerData pd;
	public MovementCardinal player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag == "Terrain")
		{
			if(collision.relativeVelocity.magnitude > 1f)
			{
				float damageTaken = 2 * collision.relativeVelocity.magnitude * (Mathf.Abs(collision.transform.position.y) * 0.1f);
				GameObject textfield = Instantiate(GameManager.Instance.damageText, player.transform.position + new Vector3(0, 1f, 0f), Quaternion.identity);
				textfield.GetComponent<PopupText>().textfield.text = Mathf.RoundToInt(damageTaken).ToString();
				pd.currentHealth -= damageTaken;
			}




			if(pd.currentHealth <= 0)
			{
				GameManager.Instance.gameState = GameState.Death;
			}
		}


    }
}
