using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class MovementCardinal : MonoBehaviour
{
	public AudioSource audioSource;

	PlayerData playerData;
	public Rigidbody2D rb;

	public bool inBase;

	Vector2 inputDirection = new Vector2();
	Vector2 currentAcceleration = new Vector2();

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		playerData = GetComponent<PlayerData>();
    }


    void FixedUpdate()
    {
		if (GameManager.Instance.gameState == GameState.Default)
		{
			TurnOffGravity();
			MovePlayer(inputDirection);
		}
		else if (GameManager.Instance.gameState == GameState.Airbourne)
		{
			TurnOnGravity();
		}
	}

	void OnCardinalMove(InputValue value)
	{
		inputDirection = value.Get<Vector2>();
	}

	void MovePlayer(Vector2 direction)
	{
		currentAcceleration = direction * playerData.cardinalAccelleration;

		if (currentAcceleration.magnitude > 0)
		{
			float factor = (Vector2.Dot(rb.velocity.normalized, direction) - 2) * -1;

			rb.velocity += factor * currentAcceleration * Time.fixedDeltaTime;
		}
		else
		{
			rb.velocity -= rb.velocity * Time.fixedDeltaTime;
		}

		if (rb.velocity.magnitude > playerData.cardinalSpeedMAX)
		{
			rb.velocity = rb.velocity.normalized * playerData.cardinalSpeedMAX;
		}

		// audioSource.volume = Mathf.Clamp((rb.velocity.magnitude / playerData.cardinalSpeedMAX), 0.5f, 1f);
	}

	public void TurnOnGravity()
	{
		rb.gravityScale = 0.85f;
	}

	public void TurnOffGravity()
	{
		rb.gravityScale = 0;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Base")
		{
			inBase = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Base")
		{
			inBase = false;
		}
	}
}
