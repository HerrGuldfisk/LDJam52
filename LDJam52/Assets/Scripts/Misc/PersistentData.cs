using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
	public static PersistentData Instance;

	public int numberOfDeaths = 5000;

    void Start()
    {
		if (Instance != null && Instance != this)
		{
			Destroy(this);
			return;
		}
		else
		{
			Instance = this;
		}

		DontDestroyOnLoad(gameObject);
    }
}
