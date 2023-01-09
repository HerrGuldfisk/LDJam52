using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VingetteDepth : MonoBehaviour
{
	UnityEngine.Rendering.Universal.Vignette vignette;
	public PlayerData pd;

	private void Start()
	{
		UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
		if (!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));

		// You can leave this variable out of your function, so you can reuse it throughout your class.

		if (!volumeProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));


	}
	// Update is called once per frame
	void Update()
    {
		if(pd.currentPressure > 50)
		{
			vignette.intensity.Override((pd.currentPressure - 50) / (pd.GAMEMAXDEPTH));
		}
	}
}
