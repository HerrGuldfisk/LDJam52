using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class MainCanvasController : MonoBehaviour
{
	public MovementCardinal player;
	public GameObject shop;
	public GameObject cptUI;
	public TextMeshProUGUI cptTextField;

	public List<string> cptDialogues = new List<string>();

	bool shopIsOpen;
    // Start is called before the first frame update
    void Start()
    {
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {

    }

	void OnOpen(InputValue value)
	{
		if(value.Get<float>() == 1 && shopIsOpen == false)
		{
			if (!player.inBase) { return; }

			shopIsOpen = true;
			shop.SetActive(true);

			cptUI.SetActive(true);

			cptTextField.text = cptDialogues[Random.Range(0, cptDialogues.Count)];

			GameManager.Instance.gameState = GameState.Shop;
			Time.timeScale = 0f;
		}
	}

	void OnClose(InputValue value)
	{
		if (value.Get<float>() == 1 && shopIsOpen == true)
		{
			shopIsOpen = false;
			shop.SetActive(false);
			cptUI.SetActive(false);
			GameManager.Instance.gameState = GameState.Default;
			Time.timeScale = 1f;
		}
	}
}
