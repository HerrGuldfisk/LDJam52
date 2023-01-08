using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PressureManager : MonoBehaviour
{
	public Sprite activePressureBar;
	public Sprite inActivePressureBar;

	public GameObject singleBarContainer;

	int maxBars = 5;

	int lastNumberOfBars = 5;

	public List<GameObject> bars = new List<GameObject>();

	private void Start()
	{
		/*
		foreach(Transform child in transform)
		{
			bars.Add(child.gameObject);
		}
		*/
	}

	public void UpdatePressure(float depth)
	{
		int numberActive = (int)(depth * -1 / 10) + 1;

		if(numberActive != lastNumberOfBars)
		{
			lastNumberOfBars = numberActive;
			UpdatePressureGraphics(Mathf.Clamp(numberActive, 0, maxBars - 1));
		}
	}

	public void UpdateMaxPressure(float value)
	{
		maxBars = (int)value / 20 ;
		int diff = maxBars - bars.Count;

		for(int i = 0; i < diff; i++)
		{
			GameObject newBar = Instantiate(singleBarContainer, transform);
			newBar.GetComponent<Image>().sprite = inActivePressureBar;
			bars.Add(newBar);
		}
	}

	void UpdatePressureGraphics(int number)
	{
		for (int i = 0; i < number; i++)
		{
			Debug.Log(bars.Count);
			Debug.Log("Active before");
			bars[i].GetComponent<Image>().sprite = activePressureBar;
			Debug.Log("Active");
		}
		for (int i = number; i < bars.Count; i++)
		{
			bars[i].GetComponent<Image>().sprite = inActivePressureBar;
			Debug.Log("InActive");
		}
	}
}
