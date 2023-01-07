using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
	List<InventorySlot> items = new List<InventorySlot>();
	private int currentlySelectedItem = 0;
	public Transform player;

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

	public void PickUp(Pickables item)
	{
		for(int i = 0; i < items.Count; i++)
		{
			if (items[i].item.sprite == null)
			{
				items[i].item.sprite = GameManager.Instance.GetImage(item);
				items[i].itemIndex = item.index;
				items[i].item.color = new Color(1, 1, 1, 1);
				Destroy(item.gameObject);
				return;
			}
		}
	}

	void OnDropItem()
	{
		if(items[currentlySelectedItem].item != null && items[currentlySelectedItem].itemIndex != -1)
		{
			Instantiate(GameManager.Instance.items[items[currentlySelectedItem].itemIndex], player.transform.position, Quaternion.identity);
			items[currentlySelectedItem].item.sprite = null;
			items[currentlySelectedItem].itemIndex = -1;
			items[currentlySelectedItem].item.color = new Color(1, 1, 1, 0);
		}
	}

}
