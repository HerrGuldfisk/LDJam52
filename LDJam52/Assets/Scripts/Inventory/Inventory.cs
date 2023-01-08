using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
	List<InventorySlot> items = new List<InventorySlot>();
	private int currentlySelectedItem = 0;
	public Transform player;
	public TextMeshProUGUI moneyText;
	public PlayerData pd;

    void Start()
    {
		foreach(Transform inventorySlot in transform)
		{
			if (inventorySlot.GetComponent<InventorySlot>())
			{
				items.Add(inventorySlot.GetComponent<InventorySlot>());
				inventorySlot.GetComponent<InventorySlot>().HideOutline();
			}
		}

		moneyText.text = pd.currentMoney.ToString() + " G";

		SetSelectedItem(0);
	}

    void SetSelectedItem(int number)
	{
		currentlySelectedItem = number;

		foreach(InventorySlot slot in items)
		{
			slot.HideOutline();
		}

		items[number].ShowOutline();
	}

	void OnBumper(InputValue value)
	{
		float bumperValue = value.Get<float>();

		if(bumperValue == 1)
		{
			if(currentlySelectedItem < items.Count - 1)
			{
				SetSelectedItem(currentlySelectedItem + 1);
			}
		}

		if (bumperValue == -1)
		{
			if (currentlySelectedItem > 0)
			{
				SetSelectedItem(currentlySelectedItem - 1);
			}
		}
	}

	void OnScroll(InputValue value)
	{
		Vector2 scrollValue = value.Get<Vector2>();

		if (scrollValue.y < 0)
		{
			if (currentlySelectedItem < items.Count - 1)
			{
				SetSelectedItem(currentlySelectedItem + 1);
			}
		}

		if (scrollValue.y > 0)
		{
			if (currentlySelectedItem > 0)
			{
				SetSelectedItem(currentlySelectedItem - 1);
			}
		}
	}

	public void PickUp(Pickables item)
	{
		for(int i = 0; i < items.Count; i++)
		{
			if (items[i].item.sprite == null)
			{
				items[i].item.sprite = GameManager.Instance.GetImage(item);
				items[i].itemIndex = item.Index;
				items[i].item.color = new Color(1, 1, 1, 1);
				Destroy(item.gameObject);
				return;
			}
		}
	}

	void OnDropItem()
	{
		if (player.GetComponent<MovementCardinal>().inBase)
		{
			for(int i = 0; i < items.Count; i++)
			{
				if (items[i].item != null && items[i].itemIndex != -1)
				{
					// Visual for selling item

					Vector2 randomOffset = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
					GameObject textObject = Instantiate(GameManager.Instance.moneyText, player.transform.position + (Vector3)randomOffset, Quaternion.identity);
					textObject.GetComponent<PopupText>().textfield.text = GameManager.Instance.items[items[i].itemIndex].GetComponent<Pickables>().Value.ToString();
					pd.currentMoney += GameManager.Instance.items[items[i].itemIndex].GetComponent<Pickables>().Value;
					moneyText.text = pd.currentMoney.ToString() + " G";
					items[i].item.sprite = null;
					items[i].itemIndex = -1;
					items[i].item.color = new Color(1, 1, 1, 0);
				}
			}
		}
		else if(items[currentlySelectedItem].item != null && items[currentlySelectedItem].itemIndex != -1)
		{
			Instantiate(GameManager.Instance.items[items[currentlySelectedItem].itemIndex], player.transform.position, Quaternion.identity);
			items[currentlySelectedItem].item.sprite = null;
			items[currentlySelectedItem].itemIndex = -1;
			items[currentlySelectedItem].item.color = new Color(1, 1, 1, 0);
		}
	}

}
