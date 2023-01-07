using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Claw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnPickUp(InputValue value)
	{
		if(value.Get<float>() == 1)
		{
			Collider2D[] results = Physics2D.OverlapCircleAll(transform.position, 0.5f);

			if(results.Length == 0) { return; }

			foreach(Collider2D col in results)
			{
				if (col.gameObject.tag == "Pickable")
				{
					// Pick up logic

					Destroy(col.gameObject);
					return;
				}
			}
		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Pickable")
		{
			Debug.Log("Pickable");
		}
		// Display pick up help text
	}
}
