using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour
{
	float time = 2f;

	public TextMeshProUGUI textfield;

    // Start is called before the first frame update
    void Start()
    {
		Destroy(gameObject, time);
    }
}
