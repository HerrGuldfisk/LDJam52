using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
	public Transform playerPos;
	public Transform background;

	Vector3 startPosBG;
	Vector3 startPosBoat;

	private void Start()
	{
		startPosBoat = playerPos.position;
		startPosBG = background.position;
	}

	void Update()
    {
		background.position = new Vector3((playerPos.position.x + startPosBoat.x) / 5, startPosBG.y, 0);
    }
}
