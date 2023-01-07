using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image item;
	public int itemIndex = -1;
	GameObject selector;

	private void Start()
	{
		selector = transform.GetChild(0).gameObject;
	}

	public void ShowOutline()
	{
		selector.SetActive(true);
	}

	public void HideOutline()
	{
		selector.SetActive(false);
	}
}
