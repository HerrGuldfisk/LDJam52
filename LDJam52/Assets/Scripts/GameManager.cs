using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameState gameState = GameState.Default;

	public List<Sprite> images = new List<Sprite>();
	public List<GameObject> items = new List<GameObject>();

	public void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public Sprite GetImage(Pickables item)
	{
		return images[item.index];
	}
}
